using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RunaSpawner : MonoBehaviour
{
    private enum SpawnerType { Disponiveis, Bloqueadas }
    [SerializeField] private SpawnerType tipo;
    [SerializeField] private List<GameObject> runas;
    private void Awake()
    {
        UpdateRunas();
    }

    public void UpdateRunas()
    {
        var disponiveis = runas.Where(r => GameStateManager.instance.runasDisponiveis.Contains(r.GetComponent<RunaId>().tipo));
        var bloqueadas = runas.Where(r => !GameStateManager.instance.runasDisponiveis.Contains(r.GetComponent<RunaId>().tipo));
        foreach (var runa in disponiveis)
        {
            runa.SetActive(!Convert.ToBoolean((int)tipo));
        }
        foreach (var runa in bloqueadas)
        {
            runa.SetActive(Convert.ToBoolean((int)tipo));
        }
    }
}
