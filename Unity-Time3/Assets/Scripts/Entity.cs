using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Entity : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum Tipo { Player, Inimigo };
    
    public Tipo tipo;
    [Header("UI")]
    public SelectedEntityIndicator indicador;
    public BarController hpbar;
    public BarController EnergyBar;

    [Header("Referencias")]
    public CharactersSetup personagem;


    [Header("Atributos")]
    public int vida;
    public int energia;
    public int agilidade;
    public int defesa;
    public int resistencia;
    public int sorte;
    public int tempVida;
    

    public float minAccuracy = 0.25f; 
    public float minEvase;

    [HideInInspector]public bool burn;
    [HideInInspector]public bool blind;
    [HideInInspector]public bool dodge;
    [HideInInspector]public bool critic;
    [HideInInspector]public bool shallowGrave;
    [HideInInspector]public bool riposte;
    [HideInInspector]public bool provoke;
    [HideInInspector]public bool protect;
    [HideInInspector]public bool thorns;
    [HideInInspector]public bool stun;
    [HideInInspector]public bool fortify;
    [HideInInspector]public int burnCounter;
    [HideInInspector]public int blindCounter;
    [HideInInspector]public int dodgeCounter;
    [HideInInspector]public int criticCounter;
    [HideInInspector]public int shallowGraveCounter;
    [HideInInspector]public int preventionCounter;
    [HideInInspector]public int provokeCounter;
    [HideInInspector]public int protectCounter;
    [HideInInspector]public int thornsCounter;
    [HideInInspector]public int fortifyCounter;
    public Entity provoker;
    public Entity protector;
    

    [Header("Contadores")]
    public int maxBurnCounter = 3;
    public int maxBlindCounter = 2;
    public int maxDodgeCounter = 2;
    public int maxCriticCounter = 3;
    public int maxShallowGraveCounter = 1;
    public int maxPreventionCounter = 2;
    public int maxProvokeCounter = 2;
    public int maxProtectCounter = 3;
    public int maxthornsCounter = 2;
    public int maxFortifyCounter = 2;

    private BattleController battleController;


    private void Awake()
    {
        battleController = FindObjectOfType<BattleController>();
        LoadInitialState();
        burnCounter = maxBurnCounter;
        blindCounter = maxBlindCounter;
        dodgeCounter = maxDodgeCounter;
        shallowGraveCounter = maxShallowGraveCounter;
        preventionCounter = maxPreventionCounter;
        provokeCounter = maxProvokeCounter;
        protectCounter = maxProtectCounter;
        thornsCounter = maxthornsCounter;
        criticCounter = maxCriticCounter;
        fortifyCounter = maxFortifyCounter;

        LoadSetup();
    }

    private void LoadSetup()
    {
        vida = personagem.vida;
        energia = personagem.energia;
        agilidade = personagem.agilidade;
        defesa = personagem.defesa;
        resistencia = personagem.resistencia;
        sorte = personagem.sorte;
    }

    private void LoadInitialState()
    {
        this.hpbar.SetMaxValue(vida);
        if (tipo == Tipo.Player)
        {
            EnergyBar.SetMaxValue(energia);
        }

        burn = false;
        blind = false;
        dodge = false;
        shallowGrave = false;
        riposte = false;
        tempVida = 0;
        provoke = false;
        provoker = null;
        thorns = false;
        critic = false;
        stun = false;
        fortify = false;
    }

    public void Burn()
    {
        removeVida(5);
        this.burnCounter--;

        if (this.burnCounter <= 0)
        {
            burnCounter = maxBurnCounter;
            burn = false;
        }
    }

    public void Blind()
    {
        float accuracy =minAccuracy - (0.25f * minAccuracy);
        this.blindCounter--;

        if (this.blindCounter <= 0)
        {
            blindCounter = maxBlindCounter;
            accuracy = this.minAccuracy;
            blind = false;
        }
    }

    public void Dodge()
    {
        this.dodgeCounter--;

        if (this.dodgeCounter <= 0)
        {
            dodgeCounter = maxDodgeCounter;
            dodge = false;
        } 
    }
     
    public void ShallowGrave()
    {
        this.shallowGraveCounter--;

        if(this.shallowGraveCounter <= 0)
        {
            shallowGraveCounter = maxShallowGraveCounter;
            shallowGrave = false;
        }

    }
     public void Prevention()
    {
        this.preventionCounter--;

        if(this.preventionCounter <= 0)
        {
            preventionCounter = maxPreventionCounter;
            tempVida = 0;
        }
    }

    public void Provoke()
    {
        this.provokeCounter--;

        if(this.provokeCounter <= 0)
        {
            provokeCounter = maxProvokeCounter;
            provoke = false;
            provoker = null;
        }
    }
    public void Protect()
    {
        this.protectCounter--;

        if(this.protectCounter <= 0)
        {
            protectCounter = maxProtectCounter;
            protect = false;
            protector = null;
        }
    }
    public void Thorns()
    {
        this.thornsCounter--;

        if(this.thornsCounter <= 0)
        {
            thornsCounter = maxthornsCounter;
            thorns = false;
        }
    }

    public void setVida(int hp)
    {
        this.vida = hp;
        this.hpbar.SetValue(this.vida);
        if (vida <= 0)
        {
            if (shallowGrave)
            {
                this.vida = 1;
                this.hpbar.SetValue(this.vida);
            }
            else
            {
                die(); 
            }
        }

    }

    public void adicionaVida(int quantidade)
    {
        setVida(vida + quantidade);
    }

    public void removeVida(int quantidade)
    {
        setVida(vida - quantidade);
    }

    private void die()
    {
        battleController.personagens.Remove(this);
        battleController.mortos.Add(this);
        if(this.tipo == Tipo.Player)
        {
            battleController.aliados.Remove(this);
        }else
        {
            battleController.inimigos.Remove(this);
        }

    }

    public void revive()
    {
        battleController.personagens.Add(this);
        battleController.mortos.Remove(this);
        setVida(personagem.vida/5);
         if(this.tipo == Tipo.Player)
        {
            battleController.aliados.Add(this);
        }else
        {
            battleController.inimigos.Add(this);
        }
    }

    public void setEnergia(int energy)
    {
        this.energia = energy;
        this.EnergyBar.SetValue(this.energia);
    }

    public void adicionaEnergia(int quantidade)
    {
        setEnergia(energia + quantidade);
    }

    public void removeEnergia(int quantidade)
    {
        setEnergia(energia - quantidade);
    }

    public void criticAura()
    {
        

        this.criticCounter--;

        if(this.criticCounter <= 0)
        {
            criticCounter = maxCriticCounter;
            critic = false;

        }
    }

    public void Fortify()
    {
        this.fortifyCounter--;

        if(this.fortifyCounter <= 0)
        {
            fortifyCounter = maxFortifyCounter;
            fortify = false;

        }
    }


    
    public void SelectAsTarget()
    {
        battleController.SetTarget(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        indicador.gameObject.transform.localScale = new Vector2(1.2f,1.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        indicador.gameObject.transform.localScale = new Vector2(1f, 1f);
    }
}
