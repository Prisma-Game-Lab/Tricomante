using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RoomSetup")]
public class RoomSetup : ScriptableObject
{
    public List<Room> rooms;
}

[System.Serializable]
public class Room
{
    [Header("INIMIGOS")]
    public EnemySetup enemy1;
    public EnemySetup enemy2l;
    public EnemySetup enemy3L;

    [Header("RUNAS")]
     public EffectsIntDictionary level = new EffectsIntDictionary()
    {
        {effects.water,1},
        {effects.fire,1},
        {effects.earth,1},
        {effects.cure,1},
        {effects.punch,1},
        {effects.pierce,1},
        {effects.cut,1},
    };

    [HideInInspector] public int timesPlayed;
}

[System.Serializable]
public class EnemySetup
{
    public int level;
    public int agilidade;
    public int defesa;
    public int resistencia;
    public int sorte;
    public int maxEnergia;
    public int maxHP;
}