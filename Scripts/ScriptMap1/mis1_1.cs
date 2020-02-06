using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class mis1_1 : MonoBehaviour
{
 
    public GameObject item3;
 

   
    // Start is called before the first frame update
    void OnMouseDown()
    {
        transform.Rotate(0, 30, 0);
        item3.transform.Rotate(0, 30, 0);
    }
    
}
