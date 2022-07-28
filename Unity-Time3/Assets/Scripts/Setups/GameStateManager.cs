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

    public int Fiapos;
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
}
