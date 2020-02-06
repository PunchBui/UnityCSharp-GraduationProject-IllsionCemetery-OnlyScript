using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CutScenePush : MonoBehaviour
{
    PlayableDirector playableDirector;
    public GameObject CutScenePadeath;
    public GameObject thisCamera;
    public GameObject CheckPowerBar;
    public GameObject UIPowerBar;
    public GameObject CameraCutScenePadeath;
    bool first = true ;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
        Destroy(CheckPowerBar);
        GameObject.FindWithTag("Player").SetActive(false);
        playableDirector.Play();
        playableDirector.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (PowerPutmission3.full && first)
        {
            first = false ;
            UIPowerBar.SetActive(false);
            playableDirector.Play();
        }
        if ((playableDirector.state == PlayState.Paused) && PowerPutmission3.full)
        {
            thisCamera.SetActive(false);
            CameraCutScenePadeath.SetActive(true);
            CutScenePadeath.SetActive(true);
            Destroy(gameObject);

        }
    }
}
