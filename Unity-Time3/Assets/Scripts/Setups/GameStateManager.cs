using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Runa
{
    fogo,
    agua,
    terra,
    cura,
    cortar,
    perfurar,
    pancada
};

[CreateAssetMenu(menuName = "GameStateManager")]
public class GameStateManager : ScriptableSingleton<GameStateManager>
{
    public List<Runa> runasDisponiveis;

    public void AddRuna(Runa tipo)
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
        AddRuna((Runa)tipo);
    }
}
