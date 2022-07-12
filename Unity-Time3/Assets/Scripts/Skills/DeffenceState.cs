using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffenceState : IState
{
    private BattleController bc; // Criar uma variável do tipo battleController

    public DeffenceState(BattleController _bc)
    {
        this.bc = _bc;
    }

    public void triggerWaterEffect()
    {
        Debug.Log("DefesaAgua");
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
