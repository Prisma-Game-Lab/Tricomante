using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GameStateManager")]
public class GameStateManager : ScriptableSingleton<GameStateManager>
{
    public List<effects> runasDisponiveis;

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

    public void UpgradeLevel(Entity ent)
    {
        var preco = 10 + 2 * ent.personagem.nivel;
        
        if (preco < fiapos)
        {
            ent.personagem.nivel++;
            fiapos -= preco;
        }
    }

    public void UpgradeRuna(RunaId runaId)
    {
        var custo = 10 + 2 * attackSetup.nivel;

        if (custo < fiapos)
        {
            attackSetup.nivel++;
            supportSetup.nivel++;
            attackSetup.nivel++;
            fiapos -= custo;
        }
    }
}
