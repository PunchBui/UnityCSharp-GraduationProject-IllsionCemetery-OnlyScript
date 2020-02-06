using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTwo : MonoBehaviour
{
    public GameObject binary_numeral ;
    bool OpenOrClose = false;

    // Update is called once per frame

    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("Stay");
            if (Input.GetKeyDown(KeyCode.E))
            {
                binary_numeral.SetActive(true);
                KManager.enableMouse();
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            binary_numeral.SetActive(false);
            KManager.disableMouse();
        }
    }

}
