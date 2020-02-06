using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DooropenMap3 : MonoBehaviour
{
    public GameObject Door;
    bool check = true;
    bool finish = true;
    public string text;
    public GameObject tuterialPanel;
    public Text textPanel;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (finish) {
                finish = false;
                textPanel.text = text;
                tuterialPanel.SetActive(true);
                KManager.enableMouse();
            }
                if (Input.GetKeyDown(KeyCode.E) && check)
            {
                check = false;
                Door.transform.Rotate(0, 90,0 );
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !check)
        {
            check = true;
            Door.transform.Rotate(0, -90,0 );
        }
    }
}
