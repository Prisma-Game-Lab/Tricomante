using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackStates", menuName = "Setup/AttackStates")]
public class AttackStateSetup : ScriptableObject
{
    [HideInInspector] public RuneLevels runeLevels { get { return FindObjectOfType<BattleController>().activeLevels; } }
    public int waterDamage { get { return 4 + runeLevels.levels[effects.water] * 2; } }
    public int fireDamage  { get { return 4 + runeLevels.levels[effects.fire] * 2; } }
    public int cutDamage { get { return 4 + runeLevels.levels[effects.cut] * 2; } }
    public int cureDamage { get { return 4 + runeLevels.levels[effects.cure] * 2; } }
    public int pierceDamage { get { return 4 + runeLevels.levels[effects.pierce] * 2; } }
    public int punchDamage { get { return 4 + runeLevels.levels[effects.punch] * 2; } }
    public int earthDamage { get { return 4 + runeLevels.levels[effects.earth] * 2; } }

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
