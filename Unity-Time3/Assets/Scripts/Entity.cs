using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Entity : MonoBehaviour, IPointerClickHandler
{

    public enum Tipo { Player, Inimigo };
    public Tipo tipo;

    public HealthBarController hpbar;
    public CharactersSetup personagem;

    private BattleController battleController;
    
    private int vida; //static para chamar a funcao de outro script
    private int energia;
    private int agilidade;
    private int defesa;
    private int resistencia;
    private int sorte;

    private void Awake()
    {
        battleController = FindObjectOfType<BattleController>();
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
}
