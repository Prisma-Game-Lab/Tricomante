using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunaId : MonoBehaviour
{
    public effects tipo;
    private BattleController _bc;
    private void Awake()
    {
        _bc = FindObjectOfType<BattleController>();
    }

    public void SelectEffect()
    {
        _bc.SelectEffect(tipo);
    }

    
}
