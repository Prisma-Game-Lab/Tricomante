using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject selected;
    private GameObject spawnedTipo;
    private GameObject spawnedElemento;

    public void ResetIndicators()
    {
        Destroy(spawnedTipo);
        Destroy(spawnedElemento);
    }

    public void SwitchSelectionTipo(GameObject button)
    {
        Destroy(spawnedTipo);
        spawnedTipo = SpawnSelected(button, 115);
    }

    public void SwitchSelectionElemento(GameObject button)
    {
        Destroy(spawnedElemento);
        spawnedElemento = SpawnSelected(button, 145);
    }
    
    private GameObject SpawnSelected(GameObject button, int positionOffset)
    {
        var new_display = Instantiate(selected, button.transform.position, Quaternion.identity, button.transform);
        new_display.GetComponent<RectTransform>().SetParent(button.GetComponent<RectTransform>());
        new_display.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, positionOffset);
        return new_display;
    }
}
