using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkFusedbacklip : MonoBehaviour
{
    public GameObject dailog;
    public Button close2;
    public bool checkEz;
    public GameObject fuse1;
    public GameObject fuse2;
    public Text text;

    void Start()
    {
        Button btnclose = close2.GetComponent<Button>();
        btnclose.onClick.AddListener(closedailogBacklip);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == ("Player"))
        {
            dailog.SetActive(true);
            KManager.enableMouse();
            text.text = "ตู้ลิฟนี้ดูเหมือนฟิวส์จะหายไป 2 อัน บางที่อาจจะอยู่ในบริเวณบ้านพักหลังนี้ลองหามาใส่ดูสิ";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == ("Player"))
        {
            dailog.SetActive(false);
            KManager.disableMouse();
        }
    }
    public void closedailogBacklip ()
    {
        Debug.Log("clicked");
        dailog.SetActive(false);
        KManager.disableMouse();
    }
    public void checkQuest()
    {
        Debug.Log("clicked");
        GameObject[] slot = GameObject.FindWithTag("Player").GetComponent<Inventory>().slot;
            bool checkItem1 = false;
            bool checkItem2 = false;
            for (int i = 0; i < slot.Length; i++)
            {
                //Debug.Log(slot + " + " + slotHolder.transform.GetChild(i).gameObject);
                //slot[i] = slotHolder.transform.GetChild(i).gameObject;

                if (slot[i].GetComponent<Slot>().id == 2001)
                {
                    checkItem1 = true;
                fuse1.SetActive(true);
            }
                if (slot[i].GetComponent<Slot>().id == 2002)
                {
                    checkItem2 = true;
                fuse2.SetActive(true);
            }
            }
            if (checkItem1 && checkItem2)
            {
                Done();
            }
            else
            {
                text.text = "ฟิวส์ยังไม่ครบ!!!";
            }
    }
    public void Done()
    {
        dailog.SetActive(false);
        KManager.disableMouse();
        checkEz = true;
        GetComponent<BoxCollider>().enabled = false;
        Inventory deleter = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        for (int i = 0; i < 2; i++)
        {
            deleter.deleteItemSlot("Quest");
        }
    }
}
