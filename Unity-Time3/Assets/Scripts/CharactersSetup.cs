using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Personagem",menuName = "Personagem" )]
public class CharactersSetup : ScriptableObject
{
    public int vida; //static para chamar a fun��o de outro script
    public int energia;
    public int agilidade;
    public int defesa;
    public int resistencia;
    public int sorte;
}
