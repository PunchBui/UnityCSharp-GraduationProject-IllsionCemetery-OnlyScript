using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutScenePullBack : MonoBehaviour
{
    PlayableDirector playableDirector;
    public GameObject CameralookforLocker;
    public GameObject Cutscene;
   
    GameObject MainAc;
    public GameObject CheckPullBack;
    void Start()
    {
        MainAc = GameObject.FindWithTag("Player");
        MainAc.SetActive(false);
        playableDirector = GetComponent<PlayableDirector>();
      
      

    }

    // Update is called once per framee
    void Update()
{
    if (playableDirector.state == PlayState.Paused)
    {

        MainAc.SetActive(true);
        CameralookforLocker.SetActive(false);
        Cutscene.SetActive(false);
        Destroy(CheckPullBack);
    }
}
}
