using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffenceState : IState
{
    private BattleController bc; // Criar uma vari�vel do tipo battleController

    public DeffenceState(BattleController _bc)
    {
        bc = _bc;
    }

    public void triggerWaterEffect() //o efeito da agua na defesa da uma chance de esquva do ataque 
    {
        bc.target.dodge = true;
    }
   

    public void triggerFireEffect()
    {
        bc.target.shallowGrave = true;
    }

    public void triggerEarthEffect() //da mais defesa ao personagem e aramzena o dano recebido ate quando ele atacar no proximo turno 
    {
        if(!bc.target.riposte)
        {
            bc.target.defesa += GameStateManager.instance.deffenceSetup.riposte;
            bc.target.riposte = true;   
        }

    }

    public void triggerCureEffect()
    {
       for (int i = 0; i < bc.aliados.Count; i++)
        {
           bc.aliados[i].tempVida = GameStateManager.instance.deffenceSetup.preventionHp;
        }

    }

    public void triggerPunchEffect()
    {
        bc.target.provoker = bc.GetCurrentPlayer();
        bc.target.provoke = true;
    }

    public void triggerPierceEffect()
    {
         bc.target.thorns = true;
    }

    public void triggerCutEffect()
    {
        bc.target.protector = bc.GetCurrentPlayer();
        bc.target.protect = true;
    }

}
