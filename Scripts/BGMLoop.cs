using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMLoop : MonoBehaviour
{

    public AudioSource[] MusicSources;
    //public AudioSource First;

    //public AudioClip Intro;

    public AudioClip loop;


    public bool isMute = false;
    public int MusicBPM, TimeSignature,BarsLength;

    private float LoopPointMinutes, LoopPointSeconds;
    private double Time;
    private int NextSource;

    // Start is called before the first frame update
    void Start()
    {
        LoopPointMinutes = (BarsLength * TimeSignature)/MusicBPM;
        LoopPointSeconds = LoopPointMinutes * 60;
        Time = AudioSettings.dspTime;
        //First.PlayOneShot(Intro);
        //MusicSources[0].PlayScheduled(Time); //+ Intro.length - .05914f);
        MusicSources[2].Play();
        NextSource = 1;
       // Debug.Log("Intro Length is: "+Intro.length);
        //Debug.Log("Loop Length is: "+loop.length);
        AudioListener.volume = PlayerPrefs.GetFloat("Volume",1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!MusicSources[NextSource].isPlaying && !MusicSources[2].isPlaying) //&& !First.isPlaying)
        {
            Debug.Log("Execute Loop Please");
            Time = Time + LoopPointSeconds;
            MusicSources[NextSource].PlayScheduled(Time - .00914f);
            NextSource = 1 - NextSource;
        }
    }

    public void Mute(){
      isMute = !isMute;
     AudioListener.volume = isMute ? 0 : 1;
        
    }

}
