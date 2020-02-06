using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
public class PowerPutmission3 : MonoBehaviour
{
    Image PowerBar;
    float  maxPower = 0f;
    bool check = false;
    public static GameObject Maincharater;

    public static bool full = false;
   
    void Start()
    {
        PowerBar = GetComponent<Image>();
        Maincharater =  GameObject.FindWithTag("Player");
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E))
        {
            maxPower += 0.05f;
            PowerBar.fillAmount += 0.05f;
            if (PowerBar.fillAmount == 1)
            {
                check = true;
                //  Maincharater.SetActive(false);
                Destroy(GameObject.FindWithTag("Pa"));
                full = true;
         
            }
        }
         else if (maxPower > 0f && !check)
        {
            maxPower -= 0.003f;
            PowerBar.fillAmount -= 0.003f;
        }

        //Debug.Log(PowerBar.fillAmount +"&&"+check); เช็คค่าในตอนกด
       
        
    }


}
