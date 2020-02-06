using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutSceneBoss : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    
    public GameObject CameraCutScene;
    PlayableDirector playableDirector;
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }
    void Update()
    {
        
       if (playableDirector.state == PlayState.Paused)
        {
            CameraCutScene.SetActive(false);
        }
    }

}
