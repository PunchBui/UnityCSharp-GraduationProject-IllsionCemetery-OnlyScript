using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    AudioSource[] audio;
    AudioSource BG;
    AudioSource posture;
    AudioSource MBG;
    public AudioClip walk;
    public AudioClip run;
    public AudioClip Map2BG;
    bool playingPosture;
    string oldType;
    void Start()
    {
        audio = GameObject.FindWithTag("mainCam").GetComponents<AudioSource>();
        BG = audio[0];
        posture = audio[1];
        MBG = audio[2];
        MBG.Play();
    }
    public void ChangeSound(string source,string type)
    {
        switch (source)
        {
            case "BG":
                switch (type)
                {
                    case "Map2BG":
                        BG.clip = Map2BG;
                        break;
                }
                BG.Play();
                break;
            case "posture":
                if(type != oldType)
                {
                    switch (type)
                    {
                        case "walk":
                            posture.clip = walk;
                            break;
                        case "run":
                            posture.clip = run;
                            break;
                    }
                    posture.Play();
                    oldType = type;
                }
                break;
        }
    }
    public void StopSound(string source)
    {
        switch (source)
        {
            case "BG":
                break;
            case "posture":
                posture.Pause();
                oldType = "";
                break;
        }
    }
}
