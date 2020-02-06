using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutScenePull2 : MonoBehaviour
{
    PlayableDirector playableDirector;
    public GameObject CameralookforLocker;
    public GameObject Cutscene;
    public GameObject CheckCutscenepullback;
    public static bool pull2 = false;
    public GameObject doorclode;
    public GameObject doorues;

    GameObject MainAc;
    public GameObject CheckPull2;
    // Start is called before the first frame update
    void Start()
    {
        MainAc = GameObject.FindWithTag("Player");
        MainAc.SetActive(false);
        playableDirector = GetComponent<PlayableDirector>();
        pull2 = true;
        
        Debug.Log(pull2 + "" + CutScenePull.pull1);
        if (pull2 && CutScenePull.pull1)
        {
            Destroy(GameObject.FindWithTag("PaTop"));
            doorclode.SetActive(false);
            doorues.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
        
         
        if (playableDirector.state == PlayState.Paused)
        {
            
            MainAc.SetActive(true);
            CameralookforLocker.SetActive(false);
            Cutscene.SetActive(false);
            CheckCutscenepullback.SetActive(true);
            Destroy(CheckPull2);
        }
    }
}
