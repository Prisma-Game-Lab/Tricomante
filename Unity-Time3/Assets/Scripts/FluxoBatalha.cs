using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxoBatalha : MonoBehaviour
{
    public BattleController battleController;
    public int jogadorAtual;
    public Entity lastPlayer;

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
            lastPlayer.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }
        
        var jogador = SetJogador();
        lastPlayer = jogador;

        jogador.gameObject.transform.localScale = new Vector3(2f, 2f, 1);

        if (jogador.burn)
        {
            jogador.Burn();
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
        yield return new WaitForSeconds(1);
        battleController.SetTarget(battleController.aliados[(int)Random.Range(0, battleController.aliados.Count)]);
        yield return new WaitForSeconds(1);
        EscolheRunas();
    }
    // convesar sobre o fato do inimigo ter que escolher a acao antes de realizar seu turno 
    public void EscolheRunas()
    {
        // se sortear 1 - ataque, se sortear 2 - defesa, se sortear 3 - suporte
        int tipo = Random.Range(0, 2);
        int elemento = Random.Range(1, 8);
        // 1 - agua, 2 - fogo, 3 - terra, 4 - cura, 5 - punch, 6 - pierce 7 - cortar
        if(battleController.personagens[jogadorAtual].thorns && tipo == 0)
        {
            Debug.Log("bloqueado de atacar - thorns");
            int offset = Random.Range(1,3);
            tipo += offset;
        }
        Debug.Log($"Acao do Inimigo: {tipo} {elemento}");
        battleController.ButtonChangeState(tipo);
        battleController.SelectEffect((effects) elemento);
        battleController.triggerEffect();
    }
}
