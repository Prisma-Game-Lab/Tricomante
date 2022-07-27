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
        int dano = GameStateManager.instance.attackSetup.waterDamage;
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

        int dano = GameStateManager.instance.attackSetup.fireDamage;
        int chanceFogo = GameStateManager.instance.attackSetup.burnChance;

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
        int dano = GameStateManager.instance.attackSetup.earthDamage;
        int chanceBlind = GameStateManager.instance.attackSetup.blindChance;
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
        int dano = GameStateManager.instance.attackSetup.cureDamage;

        int damage = Damage(this.bc.target, dano);
        Cura(attacker, damage);

    }


    public void triggerPunchEffect()
    {
        var attacker = bc.GetCurrentPlayer();
        int dano = GameStateManager.instance.attackSetup.punchDamage;

        Damage(this.bc.target, dano);
        this.bc.target.defesa -= GameStateManager.instance.attackSetup.defenceReduce;
    }

    public void triggerPierceEffect()
    {
        var attacker = bc.GetCurrentPlayer();
        int dano = GameStateManager.instance.attackSetup.pierceDamage;

        this.bc.target.vida -= dano;
        this.bc.target.hpbar.SetValue(this.bc.target.vida);

    }

    public void triggerCutEffect()
    {
        var attacker = bc.GetCurrentPlayer();
        int dano = GameStateManager.instance.attackSetup.cutDamage;
        for (int j = 0; j < 3; j++)
        {
            Damage(this.bc.target, dano);
        }
    }

    private int Damage(Entity target, int dano)
    {
        var attacker = bc.GetCurrentPlayer();
        float accuracy;
        float evase;

        if (attacker.provoke)
        {
            target = attacker.provoker; 
        }

        if (target.protect)
        {
            target = target.protector;
        }
        
        if (attacker.blind)
        {
            accuracy = Random.Range(0.0f, 1.0f);
        }
        else
        {
            accuracy = 2.0f;
        }
 

        if (target.dodge)
        {
            evase = Random.Range(0.0f, 1.0f);
        }
        else
        {
            evase = 2.0f;
        }

        if (target && accuracy > attacker.minAccuracy && evase > target.minEvase)
        {
            Debug.Log("Acertou ataque");
            float damage = dano / (1 + target.defesa / 100);
            if(attacker.critic)
            {
                float chance = Random.Range(0.0f, 1.0f);
                if(chance > GameStateManager.instance.supportSetup.criticChance)
                {
                    damage = damage * GameStateManager.instance.supportSetup.criticMultiplier;
                }
            }

            if(target.tempVida > 0)
            {
              target.tempVida -= (int) damage;
            }
            else
            {
             target.removeVida((int) damage);
            }
            

            if(target.riposte)
            {
                float riposteDamage = damage * GameStateManager.instance.deffenceSetup.riposteReturn;
                attacker.removeVida((int)riposteDamage);
            }       
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

