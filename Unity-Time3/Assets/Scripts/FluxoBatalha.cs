using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxoBatalha : MonoBehaviour
{
    public BattleController battleController;
    public int jogadorAtual;
    public Entity lastPlayer;

    [Header("RuneLevels")]
    public RuneLevels playerLevels;
    public RuneLevels enemyLevels;

    // Start is called before the first frame update
    void Start()
    {
      jogadorAtual = 1000;
      AvancaJogador();//chamando a funcao para a mesma ser executada
      
    }
    public void AvancaJogador()//criando uma funcao que contra o fluxo de turno de cada personagem 
    {
        battleController.ResetTarget();
        if (lastPlayer)
        {
            lastPlayer.gameObject.transform.localScale = new Vector3(1f, 1f, 1);
            lastPlayer.indicador.gameObject.SetActive(false);
        }
        
        var jogador = SetJogador();
        jogador.SelectAsPlayer();
        lastPlayer = jogador;

        jogador.gameObject.transform.localScale = new Vector3(1.2f, 1.2f, 1);

        if (jogador.burn)
        {
            jogador.Burn();
        }

        if(jogador.critic)
        {
            jogador.criticAura();
        }

        if (jogador.dodge)
        {
            jogador.Dodge();
        }

        if (jogador.shallowGrave)
        {
            jogador.ShallowGrave();
        }

        if (jogador.tempVida > 0)
        {
            jogador.Prevention();
        }
        else if (jogador.tempVida <= 0 && jogador.preventionCounter > 0)
        {
            jogador.preventionCounter = jogador.maxPreventionCounter;
        }

        if (jogador.blind)
        {
            jogador.Blind();
        }

        if(jogador.provoke)
        {
            jogador.Provoke();
        }

        if (jogador.protect)
        {
            jogador.Protect();
        }

        if (jogador.thorns)
        {
            jogador.Thorns();
        }

        if(jogador.fortify)
        {
            jogador.Fortify();
        }

        if(jogador.stun)
        {
            jogador.stun = false;
            AvancaJogador();
        }

        if (jogador.tipo == Entity.Tipo.Player)
        {
            battleController.AtivaAtaque();// se entidade for um player, o programa chamara a funcao AtivaTipos() que ira mostrar o painel dos tipos de acoes
        }
        else
        {
            StartCoroutine(AcaoInimigo());
        }
    }

    private Entity SetJogador()
    {
        if (jogadorAtual >= battleController.personagens.Count -1)
        {
            jogadorAtual = 0;
            return battleController.personagens[jogadorAtual];
        }
        return battleController.personagens[++jogadorAtual];
    }

    private IEnumerator AcaoInimigo()
    { 
        Debug.Log("Turno do inimigo");
        yield return new WaitForSeconds(2);
        EscolheRunas(SelectState(), SelectElemento());
        yield return new WaitForSeconds(2);
        SetEnemyTarget();
        yield return new WaitForSeconds(2);
        battleController.triggerEffect();

    }

    private void SetEnemyTarget()
    {
        var alvo = battleController.GetCurrentTarget();
        if (alvo.tipoAlvo != TypeAlvo.Multiplo)
        {
            if (alvo.tipoEntity == Entity.Tipo.Player)
            {
                battleController.SetTarget(battleController.inimigos[Random.Range(0, battleController.inimigos.Count)]);
            }
            else
            {
                battleController.SetTarget(battleController.aliados[Random.Range(0, battleController.aliados.Count)]);
            }
        }
    }
    // convesar sobre o fato do inimigo ter que escolher a acao antes de realizar seu turno 
    public void EscolheRunas(int state, int elemento)
    {
        Debug.Log($"Acao do Inimigo: {state} {(effects) elemento}");
        battleController.ButtonChangeState(state);
        battleController.SelectEffect((effects) elemento);
    }

    private int SelectElemento()
    {
        // effects { 0 - water, 1 - fire, 2 - earth, 3 - cure, 4 - punch, 5 - pierce, 6 - cut }
        return Random.Range(0, 7);

    }

    private int SelectState()
    {
        // states { 0 - ataque, 1 - defesa, 2 - suporte }
        var state = Random.Range(0, 2);

        if (battleController.personagens[jogadorAtual].thorns && state == 0)
        {
            Debug.Log("bloqueado de atacar - thorns");
            int offset = Random.Range(1, 3);
            state += offset;
        }

        return state;
    }
}
