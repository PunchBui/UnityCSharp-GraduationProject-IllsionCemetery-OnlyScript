using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NaPratu : MonoBehaviour
{
    public GameObject canvas;
    bool Activing;
    GameObject[] slot;
    GameObject slotHolder;
    public Text NaPraTuText;
    AudioSource laugh;
    bool checkItem1;
    bool checkItem2;
    bool checkItem3;
    string dfText = "ฮ่าๆๆๆ ข้าคือวิญญาณเฝ้าประตูแห่งนี้ ถ้าหากเจ้าอยากเ้ขาเจ้าต้องนำสิ่งสำคัญของข้ามา 3 อย่าง" +
        "1 Diary" +
        "2 เถ้ากระดูกของข้า" +
        "3 รูปครอบครัวของข้า" +
        "\nซึ่งของพวกนี้จะอยู่ในบริเวณสุสาน ถ้าเจ้านำมาครบข้าจะเปิดทางให้";

    private void Start()
    {
        slot = GameObject.FindWithTag("Player").GetComponent<Inventory>().slot;
        slotHolder = GameObject.FindWithTag("ItemManager");
        laugh = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Activing)
        {
           Activing = true;
           canvas.SetActive(true);
           KManager.enableMouse();
           NaPraTuText.text = dfText;
           laugh.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Activing = false;
            canvas.SetActive(false);
            KManager.disableMouse();
            laugh.Stop();
        }
    }
    public void exit()
    {
        canvas.SetActive(false);
        KManager.disableMouse();
    }
    public void goNextScene()
    {
        TimedSpawn.PassScene = true;
        canvas.SetActive(false);
        TimedSpawn.SpawnWave = 5;
        SceneManager.LoadScene("Map_2");
        KManager.disableMouse();
    }
    public void checkQuestItem()
    {
        checkItem1 = false;
        checkItem2 = false;
        checkItem3 = false;
        foreach(GameObject slot in GameObject.FindWithTag("Player").GetComponent<Inventory>().slot)
        {
            if (slot.GetComponent<Slot>().id == 1001)
            {
                checkItem1 = true;
                Debug.Log("g");
            }
            if (slot.GetComponent<Slot>().id == 1002)
            {
                checkItem2 = true;
                Debug.Log("g");
            }
            if (slot.GetComponent<Slot>().id == 1003)
            {
                checkItem3 = true;
                Debug.Log("g");
            }
        }
        if (checkItem1 && checkItem2 && checkItem3)
        {
            goNextScene();
            Inventory deleter = GameObject.FindWithTag("Player").GetComponent<Inventory>();
            for(int i = 0; i < 3; i++)
            {
                deleter.deleteItemSlot("Quest");
            }
        }
        else
        {
            NaPraTuText.text = "เจ้ายังเอาของมาไม่ครบ!!!";
        }
    }
}
