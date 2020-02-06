using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StratPaMap2 : MonoBehaviour
{
    public GameObject Pa;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Pa.SetActive(true);
        }
        

    }
}
