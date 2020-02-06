using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkOutFloor2 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && other.GetComponent<PlayerControl>().floor2)
        {
            other.GetComponent<PlayerControl>().floor2 = false;
        }
    }
}
