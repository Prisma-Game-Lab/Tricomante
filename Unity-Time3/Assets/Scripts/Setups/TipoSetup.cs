using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Tipos// criando uma ordem nas acoes de 0 a 2 
{
    ataque, 
    defesa, 
    apoio
}
[CreateAssetMenu(fileName = "Tipo", menuName = "Tipo")]
public class TipoSetup : ScriptableObject
{
public int valorAcao;
public int energiaGasta;
 
}
