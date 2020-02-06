using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutsceneDone : MonoBehaviour
{
    PlayableDirector playableDirector;
    public GameObject deletejume;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }
    void Update()
    {
        if (playableDirector.state == PlayState.Paused)
        {
            StartCutSceneMap2.MainCam.SetActive(true);
            Destroy(deletejume);
        }
    }
}
