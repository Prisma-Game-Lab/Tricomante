using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackStates", menuName = "AttackStates")]
public class AttackStatesSetup : ScriptableObject
{
    [Header("Atributos de dano")]
    public int waterDamage;
    public int fireDamage;
    public int cutDamage;
    public int cureDamage;
    public int pierceDamage;
    public int punchDamage;
    public int earthDamage;

    [Header("Estatisticas")]
    public float heal;
    public int burnChance;
    public int blindChance;
    public int defenceReduce;
}
