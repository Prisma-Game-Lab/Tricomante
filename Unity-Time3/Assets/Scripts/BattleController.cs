using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    public FluxoBatalha fluxo;// botando uma referencia ao script FluxoBatalha
    public GameObject tiposPanel;
    public GameObject ataquesPanel;
    [HideInInspector]public Entity target;//[HideInInspector] serve para ocultar a referencia desejada 
    [HideInInspector] public effects currentEffect;

    public RuneLevels activeLevels { get {
            return GetCurrentPlayer().tipo == Entity.Tipo.Player ? GameStateManager.instance.playerLevels : GameStateManager.instance.enemyLevels;
        } }

    public List<Entity> personagens = new List<Entity>();// quem tiver maior agilidade comeca, independente do tipo do personagem(aliado ou inimigo) 

    [HideInInspector]public List<Entity> aliados = new List<Entity>();
    [HideInInspector]public List<Entity> inimigos = new List<Entity>();
    [HideInInspector]public List<Entity> mortos = new List<Entity>();

    private IState _attackState;
    private IState _supportState;
    private IState _deffenceState;
    private IState currentState;
    public string currentStateName;

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
        setState(_attackState);
    }
    public void SetTarget(Entity ent)
    {

        if (FindObjectOfType<UIHandler>().isCombinationSelected() &&
           ((GetCurrentTarget().tipoEntity == Entity.Tipo.Inimigo && GetCurrentPlayer().tipo != ent.tipo) ||
           (GetCurrentTarget().tipoEntity == Entity.Tipo.Player && GetCurrentPlayer().tipo == ent.tipo)))
        {
            if (target && GetCurrentTarget().tipoAlvo == TypeAlvo.Unitario)
            {
                target.indicador.DisplayLowOpacity();
            }
            target = ent;
            target.indicador.SelectAsTarget();
        }

    }

    public void CheckEndBattle()
    {
        if (aliados.Count == 0 || inimigos.Count == 0)
        {
            FindObjectOfType<SceneController>().GoToScene();
        }
    }

    public void SetEnemyTarget(Entity ent)
    {
        target = ent;
        target.indicador.SelectAsTarget();
    }

    public Alvo GetCurrentTarget()
    {
        var setup = GetCurrentSetup();
        var target = new Alvo();

        switch (currentEffect)
        {
            case effects.cut:
                target = setup.cutTarget;
                break;
            case effects.water:
                target = setup.waterTarget;
                break;
            case effects.fire:
                target = setup.fireTarget;
                break;
            case effects.cure:
                target = setup.cureTarget;
                break;
            case effects.pierce:
                target = setup.pierceTarget;
                break;
            case effects.punch:
                target = setup.punchTarget;
                break;
            case effects.earth:
                target = setup.earthTarget;
                break;
            default:
                Debug.Log("merda");
                break;
        };
        return target;
    }
    public void ResetTarget()
    {
        if (target)
        {
            target.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
    }
    public void FinishMove()
    {
        FindObjectOfType<UIHandler>().ResetSelection();
        DesativaAtaque();
        fluxo.AvancaJogador();
    }

    public void setState(IState newState)
    {
        this.currentState = newState;
        currentStateName = newState.GetType().Name;
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

    static string GetName<T>(Expression<Func<T>> expr)
    {
        return ((MemberExpression)expr.Body).Member.Name;
    }

    private void DefineOrdem()
    {
        personagens.Sort((b, a) => a.agilidade.CompareTo(b.agilidade)); // CompareTo compara e o Sort faz isso pra lista inteira
        
    }

    public void SelectEffect(effects effect)
    {
        currentEffect = effect;
        FindObjectOfType<UIHandler>().SwitchSelectionElemento((int)effect);
    }

    public void SelectEffect(RunaId runaId)
    {
        SelectEffect(runaId.tipo);
    }

    public void triggerEffect()
    {
        triggerEffectFromEnum(currentEffect);
    }
    public dynamic GetCurrentSetup()
    {
        switch (currentStateName)
        {
            case "AttackState":
                return GameStateManager.instance.attackSetup;
            case "DeffenceState":
                return GameStateManager.instance.deffenceSetup;
            default:
                return GameStateManager.instance.supportSetup;
        }
    }
    public void triggerEffectFromEnum(effects effect)
    {
        var player = GetCurrentPlayer();
        var setup = GetCurrentSetup();
        var energy = 0;
        switch (effect)
        {
            case effects.water:
                energy = setup.waterEnergy;
                currentState.triggerWaterEffect();
                break;
            case effects.fire:
                energy = setup.fireEnergy;
                currentState.triggerFireEffect();
                break;
            case effects.earth:
                energy = setup.earthEnergy;
                currentState.triggerEarthEffect();
                break;
            case effects.cure:
                energy = setup.cureEnergy;
                currentState.triggerCureEffect();
                break;
            case effects.punch:
                energy = setup.punchEnergy;
                currentState.triggerPunchEffect();
                break;
            case effects.pierce:
                energy = setup.pierceEnergy;
                currentState.triggerPierceEffect();
                break;
            case effects.cut:
                energy = setup.cutEnergy;
                currentState.triggerCutEffect();
                break;
        }
        if (player.tipo == Entity.Tipo.Player)
        {
            player.removeEnergia(energy);
        }
        FinishMove();
    }

    public void AtivaAtaque() // faz com que o painel dos tipos de acao apareca para o jogar ao comecar o seu turno  
    {
        ataquesPanel.SetActive(true);
    }
    public void DesativaAtaque() //nesse caso desativa o painel dos elementos
    {
        ataquesPanel.SetActive(false);
    }
    
    public void ButtonChangeState(int i)
    {
        if (i == 0)
        {
            setState(GetAttackState());
        }
        else if (i == 1)
        {
            setState(GetDeffenceState());
        }
        else 
        {
            setState(GetSupportState());
        }
        FindObjectOfType<UIHandler>().SwitchSelectionTipo(i);
    }

    public Entity GetCurrentPlayer()
    {
        return personagens[fluxo.jogadorAtual];
    }

    public void PassTurn()
    {
        Entity playerCurrent = GetCurrentPlayer();
        playerCurrent.adicionaEnergia(playerCurrent.energia / 2);
        fluxo.AvancaJogador();
    }
}