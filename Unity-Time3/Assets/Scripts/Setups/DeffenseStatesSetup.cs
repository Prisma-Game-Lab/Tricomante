using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DeffensesStates", menuName = "Setup/DeffensesStates")]
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
    public float dodgeChance;
    public int protect;
    public int preventionHp;
    public int shallowGrave;
    public int provoke;
    public int thorns;
    public int riposte;
    public float riposteReturn;


    
}

