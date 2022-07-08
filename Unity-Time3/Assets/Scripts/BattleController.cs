using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public FluxoBatalha fluxo;// botando uma referencia ao script FluxoBatalha
    private Tipos tipo;
    public GameObject tiposPanel;
    public GameObject elementosPanel;
    [HideInInspector]public GameObject activeJogador;//[HideInInspector] serve para ocultar a referencia desejada 
    [HideInInspector]public GameObject activeInimigo;//criando referencias (activeJogador,activeInimigo) do GameObject

    public List<Entity> personagens = new List<Entity>();// quem tiver maior agilidade comeca, idependente do tipo do personagem(aliado ou inimigo) 

    [HideInInspector]public List<Entity> aliados = new List<Entity>();

    [HideInInspector]public List<Entity> inimigos = new List<Entity>();

    public List<ElementsSetup> elementos = new List<ElementsSetup>();//criando uma lista pra ir adicionando os elementos 

    private IState _attackState;
    private IState _supportState;
    private IState _deffenceState;
    private IState currentState;

    private void Awake()
    {
        for (int i = 0; i < personagens.Count; i++)
        {
            if (personagens[i].tipo == Entity.Tipo.Player)
            {
                aliados.Add(personagens[i]);
            }
            else
            {
                inimigos.Add(personagens[i]);
            }
        }
    }

    private void Start()
    {
        DefineOrdem();//chamando a funcao DefineOrdem() para a mesma ser executada  

      
        _attackState = new AttackState(this);
        _supportState = new SupportState(this);
        _deffenceState = new DeffenceState(this);
        currentState = _attackState;
    }

    public void setState(IState newState)
    {
        this.currentState = newState;
    }

    public IState GetAttackState()
    {
        return _attackState;
    }

    public IState GetDeffenceState()
    {
        return _deffenceState;
    }

    public IState GetSupportState()
    {
        return _supportState;
    }


    private void DefineOrdem()
    {
        personagens.Sort((b, a) => a.agilidade.CompareTo(b.agilidade)); // CompareTo compara e o Sort faz isso pra lista inteira
        
    }

    public void triggerWaterEffect()
    {
        currentState.triggerWaterEffect();
    }

    public void triggerFireEffect()
    {
        currentState.triggerFireEffect();      
    }

    public void triggerEarthEffect()
    {
        currentState.triggerEarthEffect();       
    }

    public void triggerCureEffect()
    {
        currentState.triggerCureEffect();
    }

    public void triggerPunchEffect()
    {
        currentState.triggerPunchEffect();
    }

    public void triggerPierceEffect()
    {
        currentState.triggerPierceEffect();
    }

    public void triggerCutEffect()
    {
        currentState.triggerCutEffect();
    }

    public void triggerIntensifyEffect()
    {
        currentState.triggerIntensifyEffect();
    }

    public void AtivaTipos()// faz com que o painel dos tipos de acao apareca para o jogar ao comecar o seu turno  
    {
        tiposPanel.SetActive(true);
    }
    public void DesativaElementos()//nesse caso desativa o painel dos elementos, que por consequencia desativa o painel dos tipos 
    {
        elementosPanel.SetActive(false);
    }

    
    public void ButtonChangeState(int i)
    {
        if (i == 0)
        {
            setState(GetAttackState());
        }
        else if (i == 1)
        {
            setState(GetSupportState());
        }
        else 
        {
            setState(GetDeffenceState());
        }

        tiposPanel.SetActive(false);
        elementosPanel.SetActive(true);
    }
    public void VoltaTipo()//volta no painel dos tipos de acao 
    {
        tiposPanel.SetActive(true);
        elementosPanel.SetActive(false);
    }

    /*lista de acoes 

    public void AcrescentaElemento(ElementsSetup element)
    {
        elementos.Add(element);//adicionado elemento desejado
    }

    public void RecebeElemento(ElementsSetup element)
    {
        if (elementos.Count < 1)
        {
            AcrescentaElemento(element);//acrescenta elementos a lista 
        }
    }

    public void ResetaElementos()
    {
        elementos = new List<ElementsSetup>();// reseta a lista de lementos 
    }

    public void PlayerAction() // funcao recebe o nome dos tres elementos e a partir de uma combinacao especifica utilizada
    {
        if(tipo==Tipos.ataque)
        {
            acaoAtaque();
        }
        if(tipo==Tipos.defesa)
        {
            acaoDefesa();
        }
        if(tipo==Tipos.apoio)
        {
            acaoApoio();
        }
        fluxo.AvancaJogador();
    }
    
    
    public void RecebeTipo(int botao)//faz com que o painel dos tipos apareca para o jogador(ultizamos int + "variavel" pois declaramos um enum Tipos que ira receber numeros inteiros ) 
    {
        tipo=(Tipos) botao;
        tiposPanel.SetActive(false);
        elementosPanel.SetActive(true);
    }
     public void VoltaTipo()//volta no painel dos tipos de acao 
     {
      tiposPanel.SetActive(true);
        elementosPanel.SetActive(false);
     }
    
    public void acaoAtaque( )//ElementsSetup element ==
    {
      //float resultado = valorAcao + valorAcao * (aumenPercem/100);// resultado do ataque + tal elemento 
      /*
      if(elementos ) // caso o player venha a escolher outro elemento 
        {
           // element == ElementsSetup.Fogo
        }

      else if (elementos )
        {
            //element == ElementsSetup.Terra
        }
      else
        {

        
    }
     public void acaoDefesa()//ElementsSetup element == 
     {
        //float resultado=valorAcao + valorAcao * (aumenPercem/100);
        /*
        if (element ==  ) 
        {
           // ElementsSetup.Fogo
        }

        else if (element ==  )
        {
            //ElementsSetup.Terra
        }
        else
        {

        
    }
     public void acaoApoio()
     {
        /*if (element == ) 
        {
            //ElementsSetup.Fogo
        }

        else if (element ==  )
        {
            //ElementsSetup.Terra

        }
        else
        {

       
    }

    
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