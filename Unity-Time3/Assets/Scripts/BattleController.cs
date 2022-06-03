using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    
    public GameObject activeJogador;
    public GameObject activeInimigo;

    public List<Entity> jogadores = new List<Entity>() { personagem.agilidade };
    public List<Entity> inimigos = new List<Entity>();

    public string estilo;
    public string descricao;

    private void LoadSetup()
    {
        estilo = Elemento.estilo;
        descricao = Elemento.descricao;
    }


    private void Awake()
    {
        DefineOrdem(jogadores);


    }

    private void DefineOrdem(jogadores)
    {
        int i
        int primeiro = 0
        int segundo = 0
        int terceiro = 0


            //Não achei a função que apresenta em ordem os elementos em ordem

        for (i = 0; i < jogadores.Count ++i) 
        {
            if (jogadores[i] > primeiro)
            {
                terceiro = segundo
                primeiro = segundo
                primeiro = jogadores[i]
            }

            else if (jogadores[i] > segundo)
            {
                segundo = terceiro
                segundo = jogadores[i]
            }
            else if (jogadores[i] > terceiro)
            {
                terceiro = jogadores[i]
            }
        }

    }

    public void PlayerAction(string element, string element) // função recebe o nome dos três elementos e a partir daí, uma combinacao específica é utilizada
    {
        
    }
    /*
    public void PlayerAction(string action)
    {
        switch(action)
        {
            case "attack": 
                Attack(inimigo);
                break;
            case "heal":
                Heal(player);
                break;
            
        }
        StartCoroutine(EnemyDelay());
    }

    private IEnumerator EnemyDelay()
    {
        yield return new WaitForSeconds(1);
        EnemyAction();
    }

    public void EnemyAction()
    {
        int n = Random.Range(1,3);

         switch(n)
        {
            case 1: 
                Attack(player);
                break;
            case 2:
                Heal(inimigo);
                break;
        }
    }

    private void Attack(GameObject attacked)
    {
        var entity = attacked.GetComponent<Entity>();
        entity.hpbar.Sethealth(entity.hpbar.slider.value - 0.1f);
    }

    private void Heal(GameObject healed)
    {
        var entity = healed.GetComponent<Entity>();
        entity.hpbar.Sethealth(entity.hpbar.slider.value + 0.05f);
    }
    */
}
