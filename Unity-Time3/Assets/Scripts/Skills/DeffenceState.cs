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
        /*
        int defesa = this.bc.personagens[this.fluxo.jogadorAtual].DeffenseStatesSetup.waterdeffense;
        int chanceDodge = this.bc.personagens[this.bc.fluxo.jogadorAtual].DeffenseStatesSetup.Dodge;
        for (int i = 0; i < this.bc.aliados.count; i++)
        {
            Defense(this.bc.aliados[i],deffense);
            int Dodge = random.range(1,101);
            if(Dodge <= chanceDodge )
            {
                this.bc.aliados[i].dodge = true;
                this.bc.aliados[i].dodgeCounter = 2;
            }
        }
        this.fluxo.AvancaJogador();
        */
    }
   

    public void triggerFireEffect()
    {

    }

    public void triggerEarthEffect() //da mais defesa ao personagem e aramzena o dano recebido ate quando ele atacar no proximo turno 
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
