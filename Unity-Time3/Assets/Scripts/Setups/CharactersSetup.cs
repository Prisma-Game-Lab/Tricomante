using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Personagem",menuName = "Personagem" )]
public class CharactersSetup : ScriptableObject
{
    public int nivel;
    [HideInInspector] public int vida;
    [HideInInspector] public int energia;
    public int agilidade { get { return 1 + nivel * 2; } }
    public int defesa { get { return 10 + nivel * 5; } }
    public int resistencia { get { return 5 + nivel * 5; } }
    public int sorte { get { return 1 + nivel * 1; } }
    public int maxEnergia { get { return 10 + nivel * 6; } }
    public int maxHP { get { return 20 + nivel * 5; } }

    public void LevelUp()
    {
        nivel++;
    }

    private void OnValidate()
    {
        vida = maxHP;
        energia = maxEnergia;
    }
}
