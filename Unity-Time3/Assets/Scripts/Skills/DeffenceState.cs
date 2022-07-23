using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeffenceState : IState
{
    private BattleController bc; // Criar uma vari�vel do tipo battleController

    public DeffenceState(BattleController _bc)
    {
        this.bc = _bc;
    }

    public void triggerWaterEffect() //o efeito da agua na defesa da uma chance de esquva do ataque 
    {
        this.bc.target.dodge = true;
        
    }
   

    public void triggerFireEffect()
    {
        this.bc.target.shallowGrave = true;
    }

    public void triggerEarthEffect() //da mais defesa ao personagem e aramzena o dano recebido ate quando ele atacar no proximo turno 
    {
        this.bc.target.defesa += this.bc.GetCurrentPlayer().deffenseStatesSetup.riposte;
        this.bc.target.riposte = true;

    }

    public void triggerCureEffect()
    {
       for (int i = 0; i < this.bc.aliados.Count; i++)
        {
            this.bc.aliados[i].tempVida = this.bc.GetCurrentPlayer().deffenseStatesSetup.preventionHp;
        }

    }

    public void triggerPunchEffect()
    {
        this.bc.target.provoker = this.bc.GetCurrentPlayer();
        this.bc.target.provoke = true;
    }

    public void triggerPierceEffect()
    {

    }

    public void triggerCutEffect()
    {
        this.bc.target.protector = this.bc.GetCurrentPlayer();
        this.bc.target.protect = true;
    }

}
