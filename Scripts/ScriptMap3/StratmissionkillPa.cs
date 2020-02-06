using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StratmissionkillPa : MonoBehaviour
{
    public GameObject Canvas;
    public string text;
    public GameObject tuterialPanel;
    public Text textPanel;
    public Button Close;
     GameObject Pa;
    public GameObject CutScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Pa = GameObject.FindWithTag("Pa");
            Button BtnClose = Close.GetComponent<Button>();
            BtnClose.onClick.AddListener(CloseButton);
            Pa.SetActive(false);
            textPanel.text = text;
            tuterialPanel.SetActive(true);
            KManager.enableMouse();
        }

    }
    void CloseButton()
    {
     
        textPanel.text = text;
        tuterialPanel.SetActive(false);
        KManager.disableMouse();
        Canvas.SetActive(true);
        CutScene.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        tuterialPanel.SetActive(false);
        Canvas.SetActive(false);
    }
}
