using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RuneLevels")]
public class RuneLevels : ScriptableObject
{
    public EffectsIntDictionary levels = new EffectsIntDictionary()
    {
        {effects.water,1},
        {effects.fire,1},
        {effects.earth,1},
        {effects.cure,1},
        {effects.punch,1},
        {effects.pierce,1},
        {effects.cut,1},
    };

    public void IncreaseLevel(effects runa)
    {
        levels[runa]++;
    }    
    [System.Serializable]
    public class EffectsIntDictionary : SerializableDictionary<effects, int> { }
}