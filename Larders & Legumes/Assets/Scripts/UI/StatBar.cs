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


    public void SetStatMax(float stat)
    {
        slider.maxValue = stat;
        slider.value = stat;
        if(useGradient)
            fill.color = gradient.Evaluate(1f);
    }

    public void SetBaseHunger(float stat)
    {
        slider.maxValue = stat;
        slider.value = 0;
        if (useGradient)
            fill.color = gradient.Evaluate(1f);
    }

    public void SetValueTo(float stat)
    {
        slider.value = stat;
        
        if(useGradient)
            fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public float GetCurrentValue()
    {
        return slider.value;
    }
}
