using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dooropen : MonoBehaviour
{
    public GameObject Door;
    bool check = true; 
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && check)
            {
                check = false;
                Door.transform.Rotate(0,0,-90);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !check)
        {
            check = true;
            Door.transform.Rotate(0, 0, 90);
        }
    }
    // Update is called once per frame
   
}

