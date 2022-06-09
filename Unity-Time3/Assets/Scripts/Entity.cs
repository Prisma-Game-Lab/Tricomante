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

    public int vida;
    public int energia;
    public int agilidade;
    public int defesa;
    public string tipoResistencia;
    public int sorte;

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
        tipoResistencia = personagem.tipoResistencia;
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
