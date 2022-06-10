using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluxoBatalha : MonoBehaviour
{
    public BattleController battleController;
    private int jogadorAtual;
    // Start is called before the first frame update
    void Start()
    {
      jogadorAtual = 0;
      AvancaJogador();//chamando a funcao para a mesma ser executada
      
    }
    public void AvancaJogador()//criando uma funcao que contra o fluxo de turno de cada personagem 
    {
        var jogador = battleController.personagens[jogadorAtual++];
        if (jogador.tipo == Entity.Tipo.Player)
        {
            battleController.AtivaTipos();// se entidade for um player, o programa chamara a funcao AtivaTipos() que ira mostrar o painel dos tipos de acoes 

        }
        else
        {
            StartCoroutine(AcaoInimigo());
        }
    }
    private IEnumerator AcaoInimigo()
    {
        yield return new WaitForSeconds(2);
        AvancaJogador();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
