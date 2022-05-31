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
    
    private void Awake()
    {
        battleController = FindObjectOfType<BattleController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(tipo == Tipo.Player)
        {
            battleController.playerCS = personagem;
            
        }
        else
        {
            battleController.inimigoCS = personagem;
        }
    }
}
