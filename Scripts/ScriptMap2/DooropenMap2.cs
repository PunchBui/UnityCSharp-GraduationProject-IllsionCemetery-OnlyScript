using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DooropenMap2 : MonoBehaviour
{
    public GameObject Door;
    bool check = true;
    public string text;
    public GameObject tuterialPanel;
    public Text textPanel;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E) && check )
            {

                if (TimeSpawnMainAc.thischeck)
                {
                check = false;
                Door.transform.Rotate(0, 0, -90);
                }
                else if (!TimeSpawnMainAc.thischeck)
                {
                textPanel.text = text;
                tuterialPanel.SetActive(true);
                KManager.enableMouse();
                }
                
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
}
