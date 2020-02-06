using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class CutSceneEnd : MonoBehaviour
{
    PlayableDirector playableDirector;
    public GameObject CutSceneGoodbye;
    // Start is called before the first frame update
    void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playableDirector.state == PlayState.Paused)
        {
            if (GameObject.FindWithTag("GuMareGood") == null)
            {
                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                CutSceneGoodbye.SetActive(true);
            }
          
        }
    }
}
