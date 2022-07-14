using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Personagem",menuName = "Personagem" )]
public class CharactersSetup : ScriptableObject
{
    public int vida; 
    public int energia;
    public int agilidade;
    public int defesa;
    public string tipoResistencia; //String pq seria uma resistencia de elemento, e nao um numero
    public string tipoFraqueza; //String pq seria uma resistencia de elemento, e nao um numero
    public int sorte;
}
