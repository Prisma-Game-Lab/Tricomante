using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedEntityIndicator : MonoBehaviour
{
    private Image _img;
    public Color currentColor { get { return _img.color; } }
    private Color originalColor;
    private Color originalColorLow;
    private Color white = Color.white;

    private void Awake()
    {
        _img = GetComponent<Image>();
        originalColor = _img.color;
        originalColorLow = new Color(originalColor.r, originalColor.g, originalColor.b, 0.4f);
    }

    public void DisplayLowOpacity()
    {
        _img.color = originalColorLow;
    }

    public void SelectAsPlayer()
    {
        _img.color = white;
    }

    public void SelectAsTarget()
    {
        _img.color = originalColor;
    }
}
