using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutSceneMap2 : MonoBehaviour
{
    public GameObject CutScene;
    public static  GameObject MainCam ;

    void Start()
    {
        MainCam = GameObject.FindWithTag("mainCam");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            MainCam.SetActive(false);
            CutScene.SetActive(true);
            
        }
    }
}
