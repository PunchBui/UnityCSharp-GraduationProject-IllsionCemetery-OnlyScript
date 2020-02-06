using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutScenePull : MonoBehaviour
{
    PlayableDirector playableDirector;
    public GameObject CameralookforLocker;
    public static bool pull1 = false;
    public GameObject Cutscene;
    public GameObject doorclode;
    public GameObject doorues;
    GameObject MainAc;
    public GameObject CheckPull1;
    // Start is called before the first frame update
    void Start()
    {
        
        MainAc = GameObject.FindWithTag("Player");
        MainAc.SetActive(false);
        playableDirector = GetComponent<PlayableDirector>();
        pull1 = true;
        if (CutScenePull2.pull2 && pull1)
        {
            Destroy(GameObject.FindWithTag("PaTop"));
            doorclode.SetActive(false);
            doorues.SetActive(true);
        }

    }

    // Update is called once per framee
    void Update()
    {
        if (playableDirector.state == PlayState.Paused)
        {
            
            MainAc.SetActive(true);
            CameralookforLocker.SetActive(false);
            
            Cutscene.SetActive(false);
            Destroy(CheckPull1);
}
    }
}
