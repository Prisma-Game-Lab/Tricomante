using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeffensesStates", menuName = "DeffensesStates")]
public class DeffenseStatesSetup : ScriptableObject
{
    [Header("Atributos de defesa")]
    public int waterDeffense;
    public int fireDeffense;
    public int cutDeffense;
    public int cureDeffense;
    public int pierceDeffense;
    public int punchDeffense;
    public int earthDeffense;

    [Header("Estatisticas")]
    public float Dodge;
    public int maisDefesa;
    public int blindChance;
    public int defenceReduce;

    
}

