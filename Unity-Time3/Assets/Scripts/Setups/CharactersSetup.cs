using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Personagem",menuName = "Personagem" )]
public class CharactersSetup : ScriptableObject
{
    public int nivel;
    public int points;
    
    [HideInInspector] public int vida;
    [HideInInspector] public int energia;
    public int agilidade { get { return 1 + (nivel + _agilidade) * 2; } }
    public int defesa { get { return 10 + (nivel + _defesa) * 5; } }
    public int resistencia { get { return 5 + (nivel + _resistencia) * 5; } }
    public int sorte { get { return 1 + (nivel + _sorte) * 1; } }
    public int maxEnergia { get { return 10 + (nivel + _maxEnergia) * 6; } }
    public int maxHP { get { return 20 + (nivel + _maxHP) * 5; } }

    private int _agilidade;
    private int _defesa;
    private int _resistencia;
    private int _sorte;
    private int _maxEnergia;
    private int _maxHP;
        

    public void LevelUp()
    {
        nivel++;
        points++;
    }

    private void OnValidate()
    {
        vida = maxHP;
        energia = maxEnergia;
    }
}
