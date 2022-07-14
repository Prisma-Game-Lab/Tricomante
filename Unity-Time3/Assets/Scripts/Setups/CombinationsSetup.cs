using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Combinacao", menuName = "Combinacao")]
public class CombinationsSetup : ScriptableObject
{ 
    // Todo scriptable object e um arquivo e de pra usar o nome dele ao inves de usar uma variavel para o nome
    public int qtdAcao;
    public int energiaGasta;
    public string efeito;
}
