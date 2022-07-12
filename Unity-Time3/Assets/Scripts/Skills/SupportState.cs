using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportState : IState
{
    private BattleController bc; // Criar uma variável do tipo battleController

    public SupportState(BattleController _bc)
    {
        this.bc = _bc;
    }

    public void triggerWaterEffect()
    {
        Debug.Log("SupportAgua");
    }

    public void triggerFireEffect()
    {

    }

    public void triggerEarthEffect()
    {

    }

    public void triggerCureEffect()
    {

    }

    public void triggerPunchEffect()
    {

    }

    public void triggerPierceEffect()
    {

    }

    public void triggerCutEffect()
    {

    }

}
