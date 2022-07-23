using UnityEngine;

public class MenuInvoker : MonoBehaviour
{
    [SerializeReference] private effects effect;
    private BattleController _bc;
    private void Awake()
    {
        _bc = FindObjectOfType<BattleController>();
    }
    public void InvokeMenu(MenuInvoker currState)
    {
        _bc.SelectEffect(currState.effect);
    }
}