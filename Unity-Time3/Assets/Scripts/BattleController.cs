using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{

    public GameObject activeJogador;
    public GameObject activeInimigo;

    public List<Entity> personagens = new List<Entity>();// quem tiver maior agilidade começa, idependente do tipo do personagem 
   

    public List<ElementsSetup> elementos = new List<ElementsSetup>();

    private void Start()
    {
        DefineOrdem();
    }



    private void DefineOrdem()
    {
        personagens.Sort((b, a) => a.agilidade.CompareTo(b.agilidade)); // CompareTo compara e o Sort faz isso pra lista inteira
        
    }

    //lista de a��es 

    public void AcrescentaElemento(ElementsSetup element)
    {
        elementos.Add(element);
    }

    public void RecebeElemento(ElementsSetup element)
    {
        if (elementos.Count < 2)
        {
            AcrescentaElemento(element);
        }
    }

    public void ResetaElementos()
    {
        elementos = new List<ElementsSetup>();
    }

    public void PlayerAction() // fun��o recebe o nome dos tr�s elementos e a partir da�, uma combinacao espec�fica � utilizada
    {

    }

    public void RecebeTipo()
    {
      if(tipo==Ataque)
      {
       
      }
      if(tipo==cura)
      {

      }
      if(tipo==buff)
      {

      }

    }
    
    public void acaoAtaque()
    {
      float resultado = valorAcao + valorAcao * (aumenPercem/100);// resultado do ataque + tal elemento 

      if(elementos.Count==2) // caso o player venha a escolher outro elemento 
      {
        
      }
    }
     public void acaoDefesa()
     {
     float resultado=valorAcao + valorAcao * (aumenPercem/100);

     if (elementos.Count==2)
     {
         
     }
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