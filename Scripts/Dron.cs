using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dron : MonoBehaviour
{
    public GameObject CutScene;
    public GameObject CameraMainAc;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pa")
        {
            CutScene.SetActive(true);
            CameraMainAc.SetActive(false);
            other.gameObject.SetActive(false);
        }
        if (other.gameObject.tag == "PaTop")
        {
            CutScene.SetActive(true);
            CameraMainAc.SetActive(false);
            other.gameObject.SetActive(false);
        }

    }
}
