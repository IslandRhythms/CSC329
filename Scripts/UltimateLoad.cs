using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltimateLoad : MonoBehaviour
{


    
    public Slider slider;

    public void SetStart(int maxLoad)
    {
        slider.maxValue = maxLoad;
        slider.value = 0;
    }
    
    public void SetProgress(int Ecount)
    {
        if(Ecount <= 50)
        slider.value = Ecount;
    }
}
