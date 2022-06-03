using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Combinacao", menuName = "Combinacao")]
public class CombinationsSetup : ScriptableObject
{ 
    // Todo scriptable object é um arquivo e dá pra usar o nome dele ao invés de usar uma variável para o nome
    public int qtdAcao;
    public int energiaGasta;
    public string efeito;
}
