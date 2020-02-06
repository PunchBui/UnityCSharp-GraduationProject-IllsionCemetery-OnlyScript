using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoormis1 : MonoBehaviour
{
    public GameObject Door ;
    bool save1 = false;
    bool save2 = false;
    bool save3 = false;
    bool save4 = false;
    bool door = true;
  
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "handle1")
        {
            save1 = true;
         
        }
        if (other.tag == "handle2")
        {
            save2 = true;
           
        }
        if (other.tag == "handle3")
        {
            save3 = true;
         
        }
        if (other.tag == "handle4")
        {
            save4 = true;
        }
        if (save1 && save2 && save3 && save4)
        {
            

            if (door)
            {
                Door.transform.Rotate(0, -45, 0);
                door = false ;
                GameObject.FindWithTag("map1mis1").GetComponent<mission1>().doneMission();
            }
           
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "handle1")
        {
            save1 = false;
            
        }
        if (other.tag == "handle2")
        {
            save2 = false;
        }
        if (other.tag == "handle3")
        {
            save3 = false;
        }
        if (other.tag == "handle4")
        {
            save4 = false;
        }
    }
    
}
