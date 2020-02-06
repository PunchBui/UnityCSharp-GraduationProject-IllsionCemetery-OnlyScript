using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MomGumare : MonoBehaviour
{
    // Start is called before the first frame update
    
    string[] text;
    public GameObject tuterialPanel;
    public Text textPanel;
    public Button Ok ;
    public Button NoOk;
    public GameObject Close;
    public GameObject GameObjButtonOk;
    public GameObject GameObjButtonNoOk;
    GameObject GuMare ;
    bool finish = true;
    void Start()
    {
        
        Button btnOk = Ok.GetComponent<Button>();
        btnOk.onClick.AddListener(ButtonOk);
        Button btnNoOK = NoOk.GetComponent<Button>();
        btnNoOK.onClick.AddListener(ButtonNoOk);
        GuMare = GameObject.FindWithTag("GuMareGood");
      
    }

   
    void OnTriggerEnter(Collider other)
    {
        if (finish)
        {
            if (other.gameObject.tag == "Player")
            {
                Close.SetActive(false);
                GameObjButtonOk.SetActive(true);
                GameObjButtonNoOk.SetActive(true);
                finish = false;
                textPanel.text = "     ช่วยด้วยข้าอยากไปเกิดเหลือเกิน  แต่ข้ายังหาลูกตัวเองไม่เจอ ทำให้ข้าไม่สามารถไปเกิดได้"+"\n"+"หากกดช่วยเหลือกุมาร จะหายไปและจะได้สิ่งของตอบเเทน แต่หากกดไม่ช่วยเหลือกุมารจะไม่หายไป";
                tuterialPanel.SetActive(true);
                KManager.enableMouse();
            }
        }
    }
    void ButtonOk()
    {
        Debug.Log("0");
        if (GameObject.FindWithTag("GuMareGood") != null)
        {
            GameObject.FindWithTag("CoinManager").GetComponent<CoinManager>().updateCoin(30);
            GuMare.SetActive(false);
            Close.SetActive(true);
            GameObjButtonOk.SetActive(false);
            GameObjButtonNoOk.SetActive(false);
            tuterialPanel.SetActive(false);
            KManager.disableMouse();
            Debug.Log("1");
        }
        else
        {
            textPanel.text = "     เจ้ามันโกหก ข้าไม่เห็นมีลูกของข้าเลย";
            Debug.Log("2");
        }
    }
    void ButtonNoOk()
    {
        GameObjButtonOk.SetActive(false);
        GameObjButtonNoOk.SetActive(false);
        tuterialPanel.SetActive(false);
        Close.SetActive(true);
        KManager.disableMouse();
    }
}
