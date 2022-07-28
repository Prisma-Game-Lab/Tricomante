using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedEntityIndicator : MonoBehaviour
{
    private Color originalColor;
    private Color originalColorLow;
    private Color white = Color.white;

    private void Awake()
    {
        originalColor = GetComponent<Image>().color;
        originalColorLow = new Color(originalColor.r, originalColor.g, originalColor.b, 0.4f);
    }

    public void DisplayLowOpacity()
    {
        GetComponent<Image>().color = originalColorLow;
    }

    public void SelectAsPlayer()
    {
        GetComponent<Image>().color = white;
    }

    public void SelectAsTarget()
    {
        GetComponent<Image>().color = originalColor;
    }
}
