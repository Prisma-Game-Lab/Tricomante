 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public SceneController sceneController;
    public Slider slider;

    private void awake()
    {
       // float health = personagem.vida;
    }
    

    public void SetMaxhealth(float health)
    {
        slider.maxValue=health;
        slider.value=health;
    }

    public void Sethealth(float health)
    {
        //TODO: consertar o problema da batalha acabar quando um personagem morre
        slider.value=health;
       
    }
}
