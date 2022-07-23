using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum effects { water, fire, earth, cure, punch, pierce, cut}
public interface IState 
{
    public void triggerWaterEffect();
    public void triggerFireEffect();
    public void triggerEarthEffect();
    public void triggerCureEffect();
    public void triggerPunchEffect();
    public void triggerPierceEffect();
    public void triggerCutEffect();
}
