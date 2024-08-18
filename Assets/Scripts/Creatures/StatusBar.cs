using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxValue(int maxValue){
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    public void SetValue(int value){
        slider.value = value;
    }

    public int GetValue(){
        return (int)slider.value;
    }
}
