using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopPa : MonoBehaviour
{

    public GameObject StopPanow;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Pa"))
        {
            Debug.Log("hit");
            StopPanow.SetActive(true);
        }

    }
}
