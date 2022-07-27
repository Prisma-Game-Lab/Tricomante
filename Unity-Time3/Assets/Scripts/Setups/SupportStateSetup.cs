using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SupportStates", menuName = "Setup/SupportStates")]
public class SupportStateSetup : ScriptableObject
{
    public int heal;
    public float criticChance;
    public float criticMultiplier;
    public int fortify;
   
}
