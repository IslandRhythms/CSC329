using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopGL : MonoBehaviour
{

    public AudioSource musicSource;
    public AudioClip Intro;


    void Start()
    {
        musicSource.PlayOneShot(Intro);
        musicSource.PlayScheduled(AudioSettings.dspTime + Intro.length);// + .002109f);
        musicSource.loop = true;
        //Debug.Log(Intro.length);
    }

    void Update()
    {
        //This may look redundant, but webgl won't loop continuously without this here
        musicSource.loop = true;
    }



}
