using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Combinacao", menuName = "Combinacao")]
public class CombinationsSetup : ScriptableObject
{ 
    // Todo scriptable object � um arquivo e d� pra usar o nome dele ao inv�s de usar uma vari�vel para o nome
    public int qtdAcao;
    public int energiaGasta;
    public string efeito;
}
