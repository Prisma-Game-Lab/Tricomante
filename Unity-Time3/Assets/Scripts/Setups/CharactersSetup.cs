using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Personagem",menuName = "Personagem" )]
public class CharactersSetup : ScriptableObject
{
    public int nivel;
    public int vida; 
    public int energia;
    public int agilidade;
    public int defesa;
    public int resistencia; 
    public int sorte;
    public int maxHP;
}
