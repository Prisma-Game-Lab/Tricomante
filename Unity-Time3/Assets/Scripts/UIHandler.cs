using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject selectedHud;
    [SerializeField] private GameObject selectedTipo;
    [SerializeField] private GameObject selectedElemento;
    private bool isSelectedTipo;
    private bool isSelectedElemento;

    private void Awake()
    {
        ResetIndicators();
    }

    private void CheckSelected()
    {
        if (isSelectedTipo && isSelectedElemento)
        {
            selectedHud.SetActive(true);
        }
        else
        {
        selectedHud.SetActive(false);
        }
    }
    
    public void ResetIndicators()
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
}
