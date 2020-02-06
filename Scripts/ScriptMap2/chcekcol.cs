using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chcekcol : MonoBehaviour
{
    public GameObject CheckStartPa;
    public GameObject DoorOpen;
    public GameObject Door;
    public GameObject Pull1;
    public GameObject Pull2;
    public GameObject Text;
    void OnTriggerEnter(Collider other)
    {
           if (other.tag == "Player")
        {
            CheckStartPa.SetActive(true);
            DoorOpen.SetActive(true);
            Door.SetActive(false);
            Pull1.SetActive(true);
            Pull2.SetActive(true);
            Text.SetActive(true);
            other.GetComponent<PlayerControl>().floor2 = true;
        }    
    }
}
