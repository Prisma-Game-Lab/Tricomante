using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState // SIgnifica que essa classe herda de, ou seja tem todas as fun��es dessa classe que ela herda: a extens�o, podendo ser mais espec�ficas, e a implementa��o, podendo ter outras funcionalidades
{
    private BattleController bc; // Criar uma vari�vel do tipo battleController
    private Entity ety;

    public AttackState(BattleController _bc)
    {
        bc = _bc;
    }

    public void triggerWaterEffect()
    {
        var attacker = bc.GetCurrentPlayer();
        int dano = attacker.attackStatesSetup.waterDamage;
        if (attacker.tipo == Entity.Tipo.Player)
        {
            for (int i = 0; i < bc.inimigos.Count; i++)
            {
                Damage(bc.inimigos[i], dano);
            }
        }
        else
        {
            for (int i = 0; i < this.bc.aliados.Count; i++)
            {
                Damage(bc.aliados[i], dano);
            }
        }
    }

    public void triggerFireEffect()
    {
        var attacker = bc.GetCurrentPlayer();

        int dano = attacker.attackStatesSetup.fireDamage;
        int chanceFogo = attacker.attackStatesSetup.burnChance;

        Damage(this.bc.target, dano);
        int burnChance = Random.Range(1, 101);

        if (burnChance <= chanceFogo)
        {
            this.bc.target.burn = true;
        }

    }

    public void triggerEarthEffect()
    {
        var attacker = bc.GetCurrentPlayer();
        int dano = attacker.attackStatesSetup.earthDamage;
        int chanceBlind = attacker.attackStatesSetup.blindChance;
        Damage(this.bc.target, dano);
        int blindChance = Random.Range(1, 101);

        if (blindChance <= chanceBlind)
        {
            this.bc.target.blind = true;
        }
    }

    public void triggerCureEffect()
    {
        var attacker = bc.GetCurrentPlayer();
        int dano = attacker.attackStatesSetup.cureDamage;

        int damage = Damage(this.bc.target, dano);
        Cura(attacker, damage);

    }


    public void triggerPunchEffect()
    {
        var attacker = bc.GetCurrentPlayer();
        int dano = attacker.attackStatesSetup.punchDamage;

        Damage(this.bc.target, dano);
        this.bc.target.defesa -= 5;
    }

    public void triggerPierceEffect()
    {
        var attacker = bc.GetCurrentPlayer();
        int dano = attacker.attackStatesSetup.pierceDamage;

        this.bc.target.vida -= dano;
        this.bc.target.hpbar.SetValue(this.bc.target.vida);

    }

    public void triggerCutEffect()
    {
        var attacker = bc.GetCurrentPlayer();
        int dano = attacker.attackStatesSetup.cutDamage;
        for (int j = 0; j < 3; j++)
        {
            Damage(this.bc.target, dano);
        }
    }

    private int Damage(Entity target, int dano)
    {
        var attacker = bc.GetCurrentPlayer();
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

        if (target && accuracy > attacker.minAccuracy)
        {
            Debug.Log("Acertou ataque" +
                "");
            float damage = dano / (1 + target.defesa / 100);
            target.removeVida((int) damage);       
            return (int) damage;
        }
        else
        {
            Debug.Log("Errou ataque");
            return 0;
        }
    }

    private void Cura(Entity aliado, int damage)
    {
        aliado.adicionaVida((int) (damage * 0.25f));
    }
}

