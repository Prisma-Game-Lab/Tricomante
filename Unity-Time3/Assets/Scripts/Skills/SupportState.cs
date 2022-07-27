using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportState : IState
{
    private BattleController bc; // Criar uma vari�vel do tipo battleController

    public SupportState(BattleController _bc)
    {
        this.bc = _bc;
    }

    public void triggerWaterEffect()
    {
        Debug.Log("SupportAgua");
        bc.target.revive();
      
    }

    public void triggerFireEffect()
    {
        for(int i = 0; i < this.bc.aliados.Count;i++)
        {
            this.bc.aliados[i].critic = true;
        }
    }

    public void triggerEarthEffect()
    {
        for(int i = 0; i < this.bc.aliados.Count;i++)
        {
            if(this.bc.aliados[i].fortify)
            {
                this.bc.aliados[i].fortifyCounter = this.bc.aliados[i].maxFortifyCounter;
            }else
            {
                this.bc.aliados[i].fortify = true;
                this.bc.aliados[i].resistencia += GameStateManager.instance.supportSetup.fortify;
            }
        }
        
    }

    public void triggerCureEffect()
    {
        cura(this.bc.target);
    }

    public void triggerPunchEffect()
    {
        bc.target.stun = true;
    }

    public void triggerPierceEffect()
    {
        bc.target.dodge = false;
        bc.target.dodgeCounter = bc.target.maxDodgeCounter;
        bc.target.protect = false;
        bc.target.protectCounter = bc.target.maxProtectCounter;
        bc.target.protector = null;
        bc.target.shallowGrave = false;
        bc.target.shallowGraveCounter = bc.target.maxShallowGraveCounter;
        if(bc.target.riposte)
        {
            bc.target.riposte = false;
            bc.target.defesa -=  GameStateManager.instance.deffenceSetup.riposte;
        }
        bc.target.critic = false;
        bc.target.criticCounter = bc.target.maxCriticCounter;
        if(bc.target.fortify)
        {
            bc.target.fortify = false;
            bc.target.fortifyCounter = bc.target.maxFortifyCounter;
            bc.target.resistencia -= GameStateManager.instance.supportSetup.fortify;
        }
        bc.target.preventionCounter = bc.target.maxPreventionCounter;
        bc.target.tempVida = 0;


        
    }

    public void triggerCutEffect()
    {
        bc.target.burn = false;
        bc.target.burnCounter = bc.target.maxBurnCounter;
        bc.target.blind = false;
        bc.target.blindCounter =  bc.target.maxBlindCounter;
        bc.target.provoke = false;
        bc.target.provokeCounter =  bc.target.maxProvokeCounter;
        bc.target.provoker = null;
        bc.target.thorns = false;
        bc.target.thornsCounter =  bc.target.maxthornsCounter;
        bc.target.stun = false;

        

    }


    public void cura(Entity target)
    {
        if(target.vida + GameStateManager.instance.supportSetup.heal > target.personagem.maxHP)
        {
            target.setVida(target.personagem.maxHP);
        }
        else
        {
            target.adicionaVida(GameStateManager.instance.supportSetup.heal);
        }
    }


}
