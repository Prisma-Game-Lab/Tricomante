using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : IState // SIgnifica que essa classe herda de, ou seja tem todas as fun��es dessa classe que ela herda: a extens�o, podendo ser mais espec�ficas, e a implementa��o, podendo ter outras funcionalidades
{
    private BattleController bc; // Criar uma vari�vel do tipo battleController


    public AttackState(BattleController _bc)
    {
        this.bc = _bc;
    }

    public void triggerWaterEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.waterDamage;
        if (this.bc.aliados.Contains(this.bc.personagens[this.bc.fluxo.jogadorAtual]))
        {
            for (int i = 0; i < this.bc.inimigos.Count; i++)
            {
                Damage(this.bc.inimigos[i], dano);
            }
            this.bc.fluxo.AvancaJogador();
        }
        else
        {
            for (int i = 0; i < this.bc.inimigos.Count; i++)
            {
                Damage(this.bc.inimigos[i], dano);
            }
            this.bc.fluxo.AvancaJogador();
        }
        
    }

    public void triggerFireEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.fireDamage;
        int chanceFogo = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.burnChance;
        if (this.bc.aliados.Contains(this.bc.personagens[this.bc.fluxo.jogadorAtual]))
        {
            for (int i = 0; i < this.bc.inimigos.Count; i++)
            {
                Damage(this.bc.inimigos[i], dano);
                int burnChance = Random.Range(1, 101);

                if (burnChance <= chanceFogo)
                {
                    this.bc.inimigos[i].burn = true;
                    this.bc.inimigos[i].burnCounter = 3;
                }

            }
        }
        else
        {
            for (int i = 0; i < this.bc.aliados.Count; i++)
            {
                Damage(this.bc.aliados[i], dano);
                int burnChance = Random.Range(1, 101);

                if (burnChance <= chanceFogo)
                {
                    this.bc.inimigos[i].burn = true;
                    this.bc.inimigos[i].burnCounter = 3;
                }

            }
        }

        
        this.bc.fluxo.AvancaJogador();
    }

    public void triggerEarthEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.earthDamage;
        int chanceBlind = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.blindChance;
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i], dano);
            int blindChance = Random.Range(1, 101);
            
            if (blindChance <= chanceBlind)
            {
                this.bc.inimigos[i].blind = true;
                this.bc.inimigos[i].blindCounter = 3;
            }
        }
        this.bc.fluxo.AvancaJogador();
    }

    public void triggerCureEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.cureDamage;
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            int damage = Damage(this.bc.inimigos[i], dano);
            Cura(this.bc.aliados[i], damage);
        }
    }


    public void triggerPunchEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.punchDamage;
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i], dano);
            this.bc.inimigos[i].defesa -= 5;
        }
    }

    public void triggerPierceEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.pierceDamage;
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {           
            this.bc.inimigos[i].vida -= dano;
            this.bc.inimigos[i].hpbar.Sethealth(this.bc.inimigos[i].vida);
        }
    }

    public void triggerCutEffect()
    {
        int dano = this.bc.personagens[this.bc.fluxo.jogadorAtual].attackStatesSetup.cutDamage;
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Damage(this.bc.inimigos[i], dano);
            }
            
        }
    }

    private int Damage(Entity target, int dano) // recebe o alvo
    {
        Debug.Log(target);
        float damage = dano / (1 + target.defesa / 100);        
        target.removeVida((int) damage);       
        return (int)damage;
    }

    private void Cura(Entity aliados, int damage)
    {
        aliados.vida += (int) (damage * 0.25);
    }
}

