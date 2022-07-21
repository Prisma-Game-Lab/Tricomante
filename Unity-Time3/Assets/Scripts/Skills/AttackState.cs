using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState // SIgnifica que essa classe herda de, ou seja tem todas as fun��es dessa classe que ela herda: a extens�o, podendo ser mais espec�ficas, e a implementa��o, podendo ter outras funcionalidades
{
    private BattleController bc; // Criar uma vari�vel do tipo battleController
    private Entity ety;

    public AttackState(BattleController _bc)
    {
        this.bc = _bc;
    }

    public void triggerWaterEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.waterDamage;
        if (this.bc.personagens[this.bc.fluxo.jogadorAtual].tipo == Entity.Tipo.Player)
        {
            for (int i = 0; i < this.bc.inimigos.Count; i++)
            {
                Damage(this.bc.inimigos[i], dano);
            }
        }
        else
        {
            for (int i = 0; i < this.bc.aliados.Count; i++)
            {
                Damage(this.bc.aliados[i], dano);
            }
        }
    }

    public void triggerFireEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.fireDamage;
        int chanceFogo = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.burnChance;

        Damage(this.bc.target, dano);
        int burnChance = Random.Range(1, 101);

        if (burnChance <= chanceFogo)
        {
            this.bc.target.burn = true;
        }

    }

    public void triggerEarthEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.earthDamage;
        int chanceBlind = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.blindChance;
        Damage(this.bc.target, dano);
        int blindChance = Random.Range(1, 101);

        if (blindChance <= chanceBlind)
        {
            this.bc.target.blind = true;
        }
    }

    public void triggerCureEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.cureDamage;

        int damage = Damage(this.bc.target, dano);
        Cura(this.bc.personagens[this.bc.fluxo.jogadorAtual], damage);

    }


    public void triggerPunchEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.punchDamage;

        Damage(this.bc.target, dano);
        this.bc.target.defesa -= 5;
    }

    public void triggerPierceEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.pierceDamage;

        this.bc.target.vida -= dano;
        this.bc.target.hpbar.Sethealth(this.bc.target.vida);

    }

    public void triggerCutEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.cutDamage;
        for (int j = 0; j < 3; j++)
        {
            Damage(this.bc.target, dano);
        }
    }

    private int Damage(Entity target, int dano)
    {
        float accuracy;

        if (target.blind)
        {
            accuracy = Random.Range(0.0f, 1.0f);
        }
        else
        {
            accuracy = 2.0f;
        }

        Debug.Log(accuracy);

        if (target && accuracy > this.bc.personagens[this.bc.fluxo.jogadorAtual].minAccuracy)
        {           
            float damage = dano / (1 + target.defesa / 100);
            target.removeVida((int) damage);       
            return (int) damage;
        }
        else
        {
            return 0;
        }
    }

    private void Cura(Entity aliado, int damage)
    {
        aliado.adicionaVida((int) (damage * 0.25f));
    }
}

