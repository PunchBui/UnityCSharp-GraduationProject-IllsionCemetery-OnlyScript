using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnitem : MonoBehaviour
{
    public GameObject [] spawnee;
    public GameObject[]  Spawnpoint;

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < Spawnpoint.Length; i++) {
            Instantiate(spawnee[GetRandom(spawnee.Length)],Spawnpoint[i].transform.position, Spawnpoint[i].transform.rotation);
        }
    }
    int GetRandom(int count)
    {
        return Random.Range(0, count);
    }
   
       
}



