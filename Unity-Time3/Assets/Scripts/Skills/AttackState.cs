using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState // SIgnifica que essa classe herda de, ou seja tem todas as funções dessa classe que ela herda: a extensão, podendo ser mais específicas, e a implementação, podendo ter outras funcionalidades
{
    private BattleController bc; // Criar uma variável do tipo battleController

    public AttackState(BattleController _bc)
    {
        this.bc = _bc;
    }

    public void triggerWaterEffect()
    {
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i]);
        }
        this.bc.fluxo.AvancaJogador();
    }

    public void triggerFireEffect()
    {
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i]);
            int burnChance= Random.Range(1,101);
            if (burnChance <= 100 )
            {
                this.bc.inimigos[i].burn = true;
                this.bc.inimigos[i].burnCounter = 3;
            }

        }
        this.bc.fluxo.AvancaJogador();
    }

    public void triggerEarthEffect()
    {
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i]);

        }
        this.bc.fluxo.AvancaJogador();
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

    public void triggerIntensifyEffect()
    {

    }

    private void Damage(Entity target) // recebe o alvo
    {
        Debug.Log(target);
        float damage = 10 / (1 + target.defesa / 100);        
        target.vida -= (int) damage;       
        target.hpbar.Sethealth(target.vida);   
    }
}

