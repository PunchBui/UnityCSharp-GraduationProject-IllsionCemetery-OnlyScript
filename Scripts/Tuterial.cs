using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuterial : MonoBehaviour
{
    bool finish;
    public string text;
    public GameObject tuterialPanel;
    public Text textPanel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !finish)
        {
            textPanel.text = text;
            tuterialPanel.SetActive(true);
            finish = true;
            KManager.enableMouse();
        }
    }
    public void exit()
    {
        KManager.disableMouse();
    }
}
