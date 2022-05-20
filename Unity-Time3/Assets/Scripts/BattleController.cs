using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    
    public void PlayerAction(string action)
    {
        switch(action)
        {
            case "attack": 
                Attack(enemy);
                break;
            case "heal":
                Heal(player);
                break;
            
        }

        EnemyAction(Random.range(1,2));
    }

    public void EnemyAction(int n)
    {
         switch(n)
        {
            case 1: 
                Attack(player);
                break;
            case 2:
                Heal(enemy);
                break;
            
        }
    }

    private void Attack(GameObject attacked)
    {
        var bar = attacked.GetComponent<Entity>();
        bar.hpbar = 
    }

    
}
