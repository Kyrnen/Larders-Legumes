using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StatBar : MonoBehaviour
{

    public Slider slider;

    public bool useGradient = false;
    public Gradient gradient;
    public Image fill;


    public void SetStatMax(int stat)
    {
        slider.maxValue = stat;
        slider.value = stat;
        if(useGradient)
            fill.color = gradient.Evaluate(1f);
    }

    public void SetStat(int stat)
    {
        slider.value = stat;
        
        if(useGradient)
            fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
