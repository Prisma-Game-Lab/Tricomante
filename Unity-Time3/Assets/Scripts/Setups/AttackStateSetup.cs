using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackStates", menuName = "Setup/AttackStates")]
public class AttackStateSetup : ScriptableObject
{
    [Header("Nivel runa")]
    public Dictionary<int,int> levels = new Dictionary<int, int>()
    {
        {0,1},//water = 0
        {1,1},// fire = 1
        {2,1},// earth = 2
        {3,1},// cure = 3
        {4,1},// punch = 4
        {5,1},// pierce = 5
        {6,1},// cut = 6
    };
    public int nivel;
    public int waterDamage { get { return 4 + levels[0] * 2; } }
    public int fireDamage  { get { return 4 + levels[1] * 2; } }
    public int cutDamage { get { return 4 + levels[6] * 2; } }
    public int cureDamage { get { return 4 + levels[3] * 2; } }
    public int pierceDamage { get { return 4 + levels[5] * 2; } }
    public int punchDamage { get { return 4 + levels[4] * 2; } }
    public int earthDamage { get { return 4 + levels[2] * 2; } }

    [Header("Estatisticas")]
    public int waterEnergy;
    public int fireEnergy;
    public int cutEnergy;
    public int cureEnergy;
    public int pierceEnergy;
    public int punchEnergy;
    public int earthEnergy;


    [Header("Estatisticas")]
    public float heal;
    public int burnChance;
    public int blindChance;
    public int defenceReduce;

    [Header("Alvos")]
    public Alvo waterTarget;
    public Alvo fireTarget;
    public Alvo cutTarget;
    public Alvo cureTarget;
    public Alvo pierceTarget;
    public Alvo punchTarget;
    public Alvo earthTarget;

}

public enum TypeAlvo { Unitario, Multiplo }

[System.Serializable]
public class Alvo
{
    public TypeAlvo tipoAlvo;
    public Entity.Tipo tipoEntity;
}
