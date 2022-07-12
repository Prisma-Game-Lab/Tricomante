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
            this.bc.inimigos[i].burnCounter = 3;
            if (burnChance <= 100 )
            {
                this.bc.inimigos[i].burn = true;
                
            }

        }
        this.bc.fluxo.AvancaJogador();
    }

    public void triggerEarthEffect()
    {
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i]);
            int bindChance = Random.Range(1, 101);
            this.bc.inimigos[i].bindCounter = 3;
            if (bindChance <= 100)
            {
                this.bc.inimigos[i].bind = true;
                
            }
        }
        this.bc.fluxo.AvancaJogador();
    }

    public void triggerCureEffect()
    {
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i]);
            Cura(this.bc.personagem[i]);
        }
    }


    public void triggerPunchEffect()
    {
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i]);
            LowerDefense(this.bc.inimigos[i]);
        }
    }

    public void triggerPierceEffect()
    {
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i]);
            //TODO fazer o golpe perfuar o inimigo
        }
    }

    public void triggerCutEffect()
    {
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i]);// será eu nesse caso não seria apenas questão de animação?
        }
    }

    public void triggerIntensifyEffect()
    {
        for (int i = 0; i < this.bc.inimigos.Count; i++)
        {
            Damage(this.bc.inimigos[i]); // que efeito é esse mesmo???
        }
    }

    private void Damage(Entity target) // recebe o alvo
    {
        Debug.Log(target);
        float damage = 10 / (1 + target.defesa / 100);        
        target.vida -= (int) damage;       
        target.hpbar.Sethealth(target.vida);   
    }

    private void Cura(Entity aliados, int damage)
    {
        aliados.vida += damage * (1 / 4);
    }

    private void LowerDefense(Entity target)
    {
        float LwrDmg = target.defesa - 5;
        target.defesa -= (int) LwrDmg;
    }
}

