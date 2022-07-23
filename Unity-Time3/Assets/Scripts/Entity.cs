using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Entity : MonoBehaviour, IPointerClickHandler
{
    public enum Tipo { Player, Inimigo };
    
    public Tipo tipo;
    [Header("Referencias")]
    public BarController hpbar;
    public CharactersSetup personagem;
    public BarController EnergyBar;
    public AttackStatesSetup attackStatesSetup;
    public DeffenseStatesSetup deffenseStatesSetup;

    private BattleController battleController;

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
    [HideInInspector]public int burnCounter;
    [HideInInspector]public int blindCounter;
    [HideInInspector]public int dodgeCounter;
    [HideInInspector]public int criticCounter;
    [HideInInspector]public int shallowGraveCounter;
    [HideInInspector]public int preventionCounter;
    

    [Header("Contadores")]
    public int maxBurnCounter = 3;
    public int maxBlindCounter = 2;
    public int maxDodgeCounter = 2;
    public int maxCriticCounter = 3;
    public int maxShallowGraveCounter = 1;
    public int maxPreventionCounter = 2;



    private void Awake()
    {
        battleController = FindObjectOfType<BattleController>();
        LoadInitialState();
        burnCounter = maxBurnCounter;
        blindCounter = maxBlindCounter;
        dodgeCounter = maxDodgeCounter;
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
        battleController.aliados.Remove(this);
        battleController.mortos.Add(this);
        this.gameObject.SetActive(false);

    }

    public void revive()
    {
        battleController.personagens.Add(this);
        battleController.aliados.Add(this);
        battleController.mortos.Remove(this);
        setVida(personagem.vida/5);
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

    public void danoCritico()
    {
        

        this.criticCounter--;

        if(this.criticCounter < 0)
        {
            criticCounter = maxCriticCounter;
            critic = false;

        }
    }


    
    public void OnPointerClick(PointerEventData eventData)
    {
        battleController.SetTarget(this);
    }
    
}
