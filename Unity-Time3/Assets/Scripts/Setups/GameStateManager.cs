using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameStateManager")]
public class GameStateManager : ScriptableSingleton<GameStateManager>
{
    public List<effects> runasDisponiveis;

    public RuneLevels playerLevels;
    public RuneLevels enemyLevels;
    
    public AttackStateSetup attackSetup;
    public DeffenceStateSetup deffenceSetup;
    public SupportStateSetup supportSetup;

    public int fiapos;

    public void AddRuna(effects tipo)
    {
        runasDisponiveis.Add(tipo);
        var spawners = FindObjectsOfType<RunaSpawner>();

        foreach (var spawner in spawners)
        {
            spawner.UpdateRunas();
        }
    }
    public void AddRuna(RunaId runaId)
    {
        AddRuna(runaId.tipo);
    }

    public void AddRuna(int tipo)
    {
        AddRuna((effects)tipo);
    }

    public void LevelUpEntity(Entity ent)
    {
        var preco = 12 + 6 * ent.personagem.nivel;
        
        if (preco < fiapos)
        {
            ent.personagem.nivel++;
            fiapos -= preco;
        }
    }

    public void UpgradeRuna(effects runa)
    {
        playerLevels.IncreaseLevel(runa);
    }
    

    public void UpdateStorePrices()
    {
        var items = FindObjectsOfType<ShopItem>();
        foreach (var item in items)
        {
            item.GetPrice();
        }
    }
}
