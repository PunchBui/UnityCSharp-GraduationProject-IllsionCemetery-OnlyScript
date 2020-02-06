using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrarcutSceneMap1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CutScene;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            CutScene.SetActive(true);
        }
    }
}
