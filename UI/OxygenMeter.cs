using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenMeter : MonoBehaviour
{
    public Slider oxygenSlider;
    
    public void SetMaxOxygen(float oxygen)
    {
        oxygenSlider.maxValue = oxygen;
        oxygenSlider.value = oxygen;
    }
    public void SetOxygen (float oxygen)
    {
        oxygenSlider.value = oxygen;
    }
}
