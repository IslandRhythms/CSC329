using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mask : MonoBehaviour
{

    public Image icon;

    public BGMLoop Sound;


    private bool show = false;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            show = !show;
            icon.enabled = show;
            Sound.Mute();
            
        } 
    }
}
