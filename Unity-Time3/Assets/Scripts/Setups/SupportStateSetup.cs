using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SupportStates", menuName = "Setup/SupportStates")]
public class SupportStateSetup : ScriptableObject
{
    [Header("Nivel runa")]
     /*public Dictionary<int,int> levels = new Dictionary<int, int>()
    {
        {0,1},//water = 0
        {1,1},// fire = 1
        {2,1},// earth = 2
        {3,1},// cure = 3
        {4,1},// punch = 4
        {5,1},// pierce = 5
        {6,1},// cut = 6
    };
    */
    public int nivel;

    public int heal;
    public float criticChance;
    public float criticMultiplier;
    public int fortify;

    [Header("Alvos")]
    public Alvo waterTarget;
    public Alvo fireTarget;
    public Alvo cutTarget;
    public Alvo cureTarget;
    public Alvo pierceTarget;
    public Alvo punchTarget;
    public Alvo earthTarget;

    [Header("Estatisticas")]
    public int waterEnergy;
    public int fireEnergy;
    public int cutEnergy;
    public int cureEnergy;
    public int pierceEnergy;
    public int punchEnergy;
    public int earthEnergy;

}
