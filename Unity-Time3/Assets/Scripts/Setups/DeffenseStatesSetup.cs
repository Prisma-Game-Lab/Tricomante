using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeffensesStates", menuName = "DeffensesStates")]
public class DeffenseStatesSetup : ScriptableObject
{
    
    [Header("Estatisticas")]
    public int waterEnergy;
    public int fireEnergy;
    public int cutEnergy;
    public int cureEnergy;
    public int pierceEnergy;
    public int punchEnergy;
    public int earthEnergy;

    [Header("Estatisticas")]
    public float Dodge;
    public int maisDefesa;
    public int blindChance;
    public int defenceReduce;

    
}

