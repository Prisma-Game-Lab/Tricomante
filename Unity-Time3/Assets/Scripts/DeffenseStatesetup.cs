using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeffensekStates", menuName = "DeffenseStates")]
public class DeffenseStatesSetup : ScriptableObject
{
    [Header("Atributos de defesa")]
    public int waterdeffense;
    public int firedeffense;
    public int cutdeffense;
    public int curedeffense;
    public int piercedeffense;
    public int punchdeffense;
    public int earthdeffense;

    [Header("Estatisticas")]
    public float Dodge;
    public int maisDefesa;
    public int blindChance;
    public int defenceReduce;

    
}

