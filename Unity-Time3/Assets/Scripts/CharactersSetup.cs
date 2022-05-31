using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Personagem",menuName = "Personagem" )]
public class CharactersSetup : ScriptableObject
{
    public string character;
    public float health; //static para chamar a função de outro script
    public float speed;
    public int attack;
    public float restoreHP;
    public int defense;

}
