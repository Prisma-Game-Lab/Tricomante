using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [Header("Combinacao")]
    [SerializeField] private GameObject selectedHud;
    [SerializeField] private GameObject selectedTipo;
    [SerializeField] private GameObject selectedElemento;
    private bool isSelectedTipo;
    private bool isSelectedElemento;

    [Header("Target/Attacker")]
    private BattleController _bc;


    private void Awake()
    {
        _bc = GetComponent<BattleController>();
        HideEntityIndicators();
        ResetSelection();
    }

    public bool isCombinationSelected()
    {
        return isSelectedTipo && isSelectedElemento;
    }

    private void CheckSelected()
    {
        if (isCombinationSelected())
        {
            selectedHud.SetActive(true);
            ShowEntityIndicators();
        }
        else
        {
            selectedHud.SetActive(false);
            HideEntityIndicators();
        }
    }
    
    public void ResetSelection()
    {
        selectedTipo.SetActive(false);
        isSelectedTipo = false;
        ResetElemento();
        CheckSelected();
    }

    private void ResetElemento()
    {
        selectedElemento.SetActive(false);
        isSelectedElemento = false;
        
    }

    public void SwitchSelectionTipo(int button)
    {
        ResetElemento();
        selectedTipo.SetActive(true);
        isSelectedTipo = true;
        
        var rt = selectedTipo.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(45 + 70 * button, rt.anchoredPosition.y);
        CheckSelected();
    }

    public void SwitchSelectionElemento(int button)
    {
        selectedElemento.SetActive(true);
        isSelectedElemento = true;
        button = GameStateManager.instance.runasDisponiveis.IndexOf((effects)button);
        
        var rt = selectedElemento.GetComponent<RectTransform>();
        rt.anchoredPosition = new Vector2(-98 + 70 * button, rt.anchoredPosition.y);
        CheckSelected();
    }

    private void ShowEntityIndicators()
    {

        Debug.Log(new { _bc.currentStateName, _bc.currentEffect });
        var target = _bc.GetCurrentTarget();
        var entidades = target.tipoEntity == Entity.Tipo.Player ? _bc.aliados : _bc.inimigos;
        if (target.tipoAlvo == TypeAlvo.Unitario)
        {
            foreach (var player in entidades)
            {
                player.indicador.gameObject.SetActive(true);
                player.indicador.DisplayLowOpacity();
            }
        }
        else
        {
            foreach (var player in entidades)
            {
                player.indicador.gameObject.SetActive(true);
                player.indicador.SelectAsTarget();
            }
        }

    }
    

    private void HideEntityIndicators()
    {
        _bc.personagens.ForEach(p => p.indicador.gameObject.SetActive(false));
    }
}
