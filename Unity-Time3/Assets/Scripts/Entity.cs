using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Entity : MonoBehaviour //, IPointerClickHandler
{

    public enum Tipo { Player, Inimigo };
    public Tipo tipo;

    public HealthBarController hpbar;
    public CharactersSetup personagem;
    

    private BattleController battleController;

    public int vida;
    public int energia;
    public int agilidade;
    public int defesa;
    public string tipoResistencia;
    public int sorte;

    public bool burn;
    public bool blind;
    public int burnCounter;
    public int blindCounter;

    public AttackStatesSetup attackStatesSetup;

    private void Awake()
    {
        //battleController = FindObjectOfType<BattleController>();
        LoadSetup();
        burnCounter = 3;
        blindCounter = 2;
    }

    private void LoadSetup()
    {
        vida = personagem.vida;
        energia = personagem.energia;
        agilidade = personagem.agilidade;
        defesa = personagem.defesa;
        tipoResistencia = personagem.tipoResistencia;
        sorte = personagem.sorte;

        this.hpbar.SetMaxhealth(vida);

        burn = false;
        blind = false;
    }

    public void Burn()
    {
        this.vida -= 5;
        this.hpbar.Sethealth(this.vida);
        this.burnCounter--;

        if (this.burnCounter <= 0)
        {
            burn = false;
        }
    }

    public void Blind()
    {
        this.agilidade -= 5;
        this.blindCounter--;

        if (this.blindCounter <= 0)
        {
            blind = false;
        }
    }

   
    /*
    public void OnPointerClick(PointerEventData eventData)
    {
        if(tipo == Tipo.Player)
        {
            //battleController.player = this.gameObject;
            
        }
        else
        {
            //battleController.inimigo = this.gameObject;
        }
    }
    */
}
