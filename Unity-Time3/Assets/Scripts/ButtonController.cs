using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button water;
    public Button fire;
    public Button cut;
    public Button cure;
    public Button pierce;
    public Button punch;
    public Button earth;

    private BattleController _bc;

    private void Awake()
    {
        _bc = FindObjectOfType<BattleController>();
    }

    private void Update()
    {
        CheckEnergy();
    }

    private void CheckEnergy()
    {
        var player = _bc.GetCurrentPlayer();
        var setup = _bc.GetCurrentSetup();
        
        water.interactable = setup.waterEnergy < player.energia? true: false;
        fire.interactable = setup.fireEnergy < player.energia ? true : false;
        cut.interactable = setup.cutEnergy < player.energia ? true : false;
        cure.interactable = setup.cureEnergy < player.energia ? true : false;
        pierce.interactable = setup.pierceEnergy < player.energia ? true : false;
        punch.interactable = setup.punchEnergy < player.energia ? true : false;
        earth.interactable = setup.earthEnergy < player.energia ? true : false;
    }
}
