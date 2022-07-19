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
        for(int i = 0; i < this.bc.mortos.Count;i++)
        {
            if(bc.mortos[i].tipo == this.bc.personagens[this.bc.fluxo.jogadorAtual].tipo)
            {
                bc.mortos[i].gameObject.SetActive(true);
                bc.mortos[i].revive();
                break;
            }
        }

    }

    public void triggerFireEffect()
    {
        /*int chanceCritic = this.bc.personagens[this.bc.fluxo.jogadorAtual].supportStatesSetup.criticChance;
        int criticChance = Random.Range(1,101);

        if(criticChance <= chanceCritic)
        {
          
        }
        */
    }

    public void triggerEarthEffect()
    {
        for(int i = 0; i < this.bc.aliados.Count;i++)
        {

        }
        
    }

    public void triggerCureEffect()
    {
        cura(this.bc.target);
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


    public void cura(Entity target)
    {
        target.adicionaVida(15);
    }


}
