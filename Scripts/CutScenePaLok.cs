using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutScenePaLok : MonoBehaviour
{
    PlayableDirector playableDirector;
   
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        playableDirector.Play();
    }
     void Update()
    {
        if (playableDirector.state == PlayState.Paused)
        {
            HealthBarScript.health = 0;
        }
    }
}
