using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutScenePaLook : MonoBehaviour
{
    // Start is called before the first frame update  
    PlayableDirector playableDirector ;
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playableDirector.state == PlayState.Paused)
        {
                // เรียกเม็ดตอด ตายของMainAc

        }
    }
}
