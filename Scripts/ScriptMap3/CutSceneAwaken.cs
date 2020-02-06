using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutSceneAwaken : MonoBehaviour
{
    PlayableDirector playableDirector;
  
    public GameObject CameraCutScene;
    public GameObject Cutscene;
    public GameObject CutSceneBoos;
    GameObject MainAc;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(CutSceneBoos);
        MainAc = GameObject.FindWithTag("Player");
        MainAc.SetActive(false);
        playableDirector = GetComponent<PlayableDirector>();
        

    }

    // Update is called once per frame
    void Update()
    {
         if (playableDirector.state == PlayState.Paused)
        {
            CameraCutScene.SetActive(false);
            MainAc.SetActive(true);
            Boss.SetActive(true);
            Cutscene.SetActive(false);

        }
    }
}
