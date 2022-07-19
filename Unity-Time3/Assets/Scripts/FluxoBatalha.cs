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
        Debug.Log(jogador);
        lastPlayer = jogador;

        jogador.gameObject.transform.localScale = new Vector3(2f, 2f, 1);

        if (jogador.burn)
        {
            jogador.Burn();
        }

        if (jogador.blind)
        {
            jogador.Blind();
        }

        if (jogador.tipo == Entity.Tipo.Player)
        {
            battleController.AtivaTipos();// se entidade for um player, o programa chamara a funcao AtivaTipos() que ira mostrar o painel dos tipos de acoes
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
    public void EscolheRunas()
    {
        // se sortear 1 - ataque, se sortear 2 - defesa, se sortear 3 - suporte
        int tipo = Random.Range(0, 1);
        int elemento = Random.Range(1, 8);
        // 1 - agua, 2 - fogo, 3 - terra, 4 - cura, 5 - punch, 6 - pierce 7 - cortar

        battleController.ButtonChangeState(tipo);
        if (elemento == 1)
        {
            battleController.triggerWaterEffect();
        }
        else if (elemento == 2)
        {
            battleController.triggerFireEffect();
        }
        else if (elemento == 3)
        {
            battleController.triggerEarthEffect();
        }
        else if (elemento == 4)
        {
            battleController.triggerCureEffect();
        }
        else if (elemento == 5)
        {
            battleController.triggerPunchEffect();
        }
        else if (elemento == 6)
        {
            battleController.triggerPierceEffect();
        }
        else
        {
            battleController.triggerCutEffect();
        }
    }
}
