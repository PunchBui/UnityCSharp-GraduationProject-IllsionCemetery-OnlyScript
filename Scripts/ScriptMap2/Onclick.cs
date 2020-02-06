using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Onclick : MonoBehaviour
{
    public GameObject canvas2 ;
    public GameObject canvas ;
    bool check = true ;
    public Button next;
     void Start()
    {
        Button btnnext = next.GetComponent<Button>();
        next.onClick.AddListener(OnclickNext);
    }
    void OnclickNext()
    {
        Debug.Log("ssssss");
        canvas2.SetActive(false);
        canvas.SetActive(true);
    }
   
    void OnMouseDown()
    {
         if (check)
        {
            Debug.Log("asdasd");
            canvas2.SetActive(true);
            check = false;
        }
    }

}
