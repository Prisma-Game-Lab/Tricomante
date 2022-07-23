using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public FluxoBatalha fluxo;// botando uma referencia ao script FluxoBatalha
    private Tipos tipo;
    public GameObject tiposPanel;
    public GameObject elementosPanel;
    [HideInInspector]public Entity target;//[HideInInspector] serve para ocultar a referencia desejada 
    

    public List<Entity> personagens = new List<Entity>();// quem tiver maior agilidade comeca, independente do tipo do personagem(aliado ou inimigo) 

    [HideInInspector]public List<Entity> aliados = new List<Entity>();

    [HideInInspector]public List<Entity> inimigos = new List<Entity>();

    [HideInInspector]public List<Entity> mortos = new List<Entity>();



    public List<ElementsSetup> elementos = new List<ElementsSetup>();//criando uma lista pra ir adicionando os elementos 

    private IState _attackState;
    private IState _supportState;
    private IState _deffenceState;
    private IState currentState;

    private Entity ety;

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
    public void SetTarget(Entity ent)
    {
        if (target)
        {
            target.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        target = ent;
        target.GetComponent<SpriteRenderer>().color = new Color(1, 0, 1, 1);
    }
    public void ResetTarget()
    {
        if (target)
        {
            target.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
    public void FinishMove()
    {
        DesativaElementos();
        fluxo.AvancaJogador();
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
    /*
    public IState GetCurrentState()
    {
        IState statusAtual = currentState;
        return statusAtual;
    }
    */


    private void DefineOrdem()
    {
        personagens.Sort((b, a) => a.agilidade.CompareTo(b.agilidade)); // CompareTo compara e o Sort faz isso pra lista inteira
        
    }
    
    public void triggerWaterEffect()
    {
        if (personagens[fluxo.jogadorAtual].attackStatesSetup.waterDamage <= ety.energia)
        {
            currentState.triggerWaterEffect();
            FinishMove();
        }
        else
        {
            Debug.Log("Sem energia para esse elemento");
            AtivaTipos();
        }
    }

    public void triggerFireEffect()
    {
        currentState.triggerFireEffect();
        FinishMove();
    }

    public void triggerEarthEffect()
    {
        currentState.triggerEarthEffect();
        FinishMove();
    }

    public void triggerCureEffect()
    {
        currentState.triggerCureEffect();
        FinishMove();
    }

    public void triggerPunchEffect()
    {
        currentState.triggerPunchEffect();
        FinishMove();
    }

    public void triggerPierceEffect()
    {
        currentState.triggerPierceEffect();
        FinishMove();
    }

    public void triggerCutEffect()
    {
        currentState.triggerCutEffect();
        FinishMove();
    }

    public void AtivaTipos() // faz com que o painel dos tipos de acao apareca para o jogar ao comecar o seu turno  
    {
        tiposPanel.SetActive(true);
    }
    public void DesativaElementos() //nesse caso desativa o painel dos elementos
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

    public Entity GetCurrentPlayer()
    {
        return personagens[fluxo.jogadorAtual];
    }

}