using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider slider;

    void Awake()
    {
        slider.value = PlayerPrefs.GetFloat("Volume",1f);
    }

    public void SetVolume(float volume)
    {
        //Debug.Log(volume);
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume",volume);
    }
}
