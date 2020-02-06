using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class NewBehaviourScript : MonoBehaviour
{
    PlayableDirector playableDirector;
    public GameObject CameralookforLocker;
    public GameObject Cutscene;
    GameObject MainAclip ;
    // Start is called before the first frame update
    void Start()
    {
         MainAclip =  GameObject.FindWithTag("Player");
        MainAclip.SetActive(false);
        playableDirector = GetComponent<PlayableDirector>();
    }
    void Update()
    {
        if (playableDirector.state == PlayState.Paused)
        {
            MainAclip.SetActive(true);
            CameralookforLocker.SetActive(false);
            
        }
    }
}
