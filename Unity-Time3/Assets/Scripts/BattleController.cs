using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{

    public GameObject activeJogador;
    public GameObject activeInimigo;

    public List<Entity> jogadores = new List<Entity>();
    public List<Entity> inimigos = new List<Entity>();

    public List<ElementsSetup> elementos = new List<ElementsSetup>();

    private void Start()
    {
        DefineOrdem();
    }



    private void DefineOrdem()
    {
        jogadores.Sort((a, b) => a.agilidade.CompareTo(b.agilidade)); // CompareTo compara e o Sort faz isso pra lista inteira
        inimigos.Sort((a, b) => a.agilidade.CompareTo(b.agilidade));
    }

    //lista de ações 

    public void AcrescentaElemento(ElementsSetup element)
    {
        elementos.Add(element);
    }

    public void RecebeElemento(ElementsSetup element)
    {
        if (elementos.Count < 3)
        {
            AcrescentaElemento(element);
        }
    }

    public void ResetaElementos()
    {
        elementos = new List<ElementsSetup>();
    }

    public void PlayerAction() // função recebe o nome dos três elementos e a partir daí, uma combinacao específica é utilizada
    {

    }

    public void RecebeTipo()
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