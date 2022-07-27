 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarController : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI currentText;
    public TextMeshProUGUI maxText;

    public void SetMaxValue(float value)
    {
        slider.maxValue = value;
        slider.value = value;
        
        maxText.text = $"/{(int)value}";
        currentText.text = ((int)value).ToString();
    }

    public void SetValue(float value)
    {
        slider.value=value;
        currentText.text = ((int)value).ToString();
    }
}
