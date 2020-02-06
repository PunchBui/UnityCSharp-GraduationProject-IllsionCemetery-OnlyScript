using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnwaveMap3 : MonoBehaviour
{
    public GameObject CutScene;
    public static int CountWavemap3 ;
   
    void Start()
    {
        
    }
    void Update()

    {
         if (CountWavemap3 == 1)
        {
            
            CutScene.SetActive(true);
            Destroy(gameObject);
        }
    }
}
