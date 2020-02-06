using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutScenePadeath : MonoBehaviour
{
    public GameObject thisCamera;
    public GameObject DoorS;
    public GameObject DoorNoS;
    PlayableDirector playableDirector;
    public GameObject checkPoint;
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

  
    void Update()
    {
        if (playableDirector.state == PlayState.Paused)
        {
            Destroy(checkPoint);
            DoorS.SetActive(true);
            DoorNoS.SetActive(false);
            thisCamera.SetActive(false);
            PowerPutmission3.Maincharater.SetActive(true);
            
            Destroy(gameObject);
        }
    }
}
