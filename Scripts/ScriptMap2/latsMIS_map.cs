using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class latsMIS_map : MonoBehaviour
{
    public GameObject f1 ;
    public GameObject f2 ;
    public GameObject f1_1;
    public GameObject f2_2;

    void OnMouseDown()
    {
        Debug.Log("tsetMouse");
      if (f1.active.Equals(true) && f2.active.Equals(true))
        {
            f1_1.SetActive(true);
            f2_2.SetActive(true);
        }    
    }

}
