using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Mis2 : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject chcekMIS ;  //ใช้ดูmisแรก
    //public GameObject F;
    public Text ExNum;
    public Text Position1;
    public Text Position2;
    public Text Position3;
    public Text Position4;
    public Text Position5;
    public Text Position6;
    public Text Position7;
    public Text Position8;
    public Text Textchcek;
    string A = "";
    int ExNumber;
    public Button yourButtonUp1;
    public Button yourButtonDown1;
    public Button yourButtonUp2;
    public Button yourButtonDown2;
    public Button yourButtonUp3;
    public Button yourButtonDown3;
    public Button yourButtonUp4;
    public Button yourButtonDown4;
    public Button yourButtonUp5;
    public Button yourButtonDown5;
    public Button yourButtonUp6;
    public Button yourButtonDown6;
    public Button yourButtonUp7;
    public Button yourButtonDown7;
    public Button yourButtonUp8;
    public Button yourButtonDown8;
    public Button chcekButton;
    string song = "";
    public GameObject item;
    public GameObject item2; ///ฟิวที่จะวางบนโต๊ะ
    string check ;
    public GameObject checkBg ;
    public GameObject reward;
    public Button back;
    public GameObject tutorial ;
    public GameObject CheckBox;
    void Start()
    {
        ExNumber = Random.Range(1, 255);
         A = ExNumber.ToString();
         ExNum.text = A;
        int[] ar = new int[8];
        int j = 0;
        for (j = 0; j < 8; j++)
        {
            ar[j] = 0;
        }
        int decimalNumber = 0;
        int i = 1;
        int jn = 7;
        int remainder = 0;
        while (ExNumber != 0)
        {

            remainder = ExNumber % 2;
            ar[jn] = remainder;
            ExNumber /= 2;
            decimalNumber += remainder * i;
            i *= 10;
            jn--;
        }
        for (j = 0; j < 8; j++)
        {
            song = song+ar[j].ToString();
        }
        Button btn1_1 = yourButtonUp1.GetComponent<Button>();
        btn1_1.onClick.AddListener(TaskOnClick_1_1);
        Button btn1_2 = yourButtonDown1.GetComponent<Button>();
        btn1_2.onClick.AddListener(TaskOnClick_1_2);
        Button btn2_1 = yourButtonUp2.GetComponent<Button>();
        btn2_1.onClick.AddListener(TaskOnClick_2_1);
        Button btn2_2 = yourButtonDown2.GetComponent<Button>();
        btn2_2.onClick.AddListener(TaskOnClick_2_2);
        Button btn3_1 = yourButtonUp3.GetComponent<Button>();
        btn3_1.onClick.AddListener(TaskOnClick_3_1);
        Button btn3_2 = yourButtonDown3.GetComponent<Button>();
        btn3_2.onClick.AddListener(TaskOnClick_3_2);
        Button btn4_1 = yourButtonUp4.GetComponent<Button>();
        btn4_1.onClick.AddListener(TaskOnClick_4_1);
        Button btn4_2 = yourButtonDown4.GetComponent<Button>();
        btn4_2.onClick.AddListener(TaskOnClick_4_2);
        Button btn5_1 = yourButtonUp5.GetComponent<Button>();
        btn5_1.onClick.AddListener(TaskOnClick_5_1);
        Button btn5_2 = yourButtonDown5.GetComponent<Button>();
        btn5_2.onClick.AddListener(TaskOnClick_5_2);
        Button btn6_1 = yourButtonUp6.GetComponent<Button>();
        btn6_1.onClick.AddListener(TaskOnClick_6_1);
        Button btn6_2 = yourButtonDown6.GetComponent<Button>();
        btn6_2.onClick.AddListener(TaskOnClick_6_2);
        Button btn7_1 = yourButtonUp7.GetComponent<Button>();
        btn7_1.onClick.AddListener(TaskOnClick_7_1);
        Button btn7_2 = yourButtonDown7.GetComponent<Button>();
        btn7_2.onClick.AddListener(TaskOnClick_7_2);
        Button btn8_1 = yourButtonUp8.GetComponent<Button>();
        btn8_1.onClick.AddListener(TaskOnClick_8_1);
        Button btn8_2 = yourButtonDown8.GetComponent<Button>();
        btn8_2.onClick.AddListener(TaskOnClick_8_2);
        Button chcekbtn = chcekButton.GetComponent<Button>();
        chcekbtn.onClick.AddListener(chcekNumber);
        Button Back = back.GetComponent<Button>();
        Back.onClick.AddListener(Backtutorial);
    }

    
    void TaskOnClick_1_1()
    {
        string input = "1";
        Position1.text = input;
    }
    void TaskOnClick_1_2()
    {
        string input = "0";
        Position1.text = input;
    }
    void TaskOnClick_2_1()
    {
        string input = "1";
        Position2.text = input;
    }
    void TaskOnClick_2_2()
    {
        string input = "0";
        Position2.text = input;
    }
    void TaskOnClick_3_1()
    {
        string input = "1";
        Position3.text = input;
    }
    void TaskOnClick_3_2()
    {
        string input = "0";
        Position3.text = input;
    }
    void TaskOnClick_4_1()
    {
        string input = "1";
        Position4.text = input;
    }
    void TaskOnClick_4_2()
    {
        string input = "0";
        Position4.text = input;
    }
    void TaskOnClick_5_1()
    {
        string input = "1";
        Position5.text = input;
    }
    void TaskOnClick_5_2()
    {
        string input = "0";
        Position5.text = input;
    }
    void TaskOnClick_6_1()
    {
        string input = "1";
        Position6.text = input;
    }
    void TaskOnClick_6_2()
    {
        string input = "0";
        Position6.text = input;
    }
    void TaskOnClick_7_1()
    {
        string input = "1";
        Position7.text = input;
    }
    void TaskOnClick_7_2()
    {
        string input = "0";
        Position7.text = input;
    }
    void TaskOnClick_8_1()
    {
        string input = "1";
        Position8.text = input;
    }
    void TaskOnClick_8_2()
    {
        string input = "0";
        Position8.text = input;
    }
    void Backtutorial()
    {
        gameObject.SetActive(false);
        tutorial.SetActive(true);
    }
    void chcekNumber()
    {
      
        if (song.Equals(check))
        {
           
            //chcekMIS.SetActive(true);
            gameObject.SetActive(false);
            KManager.disableMouse();
            Destroy(item);
            Destroy(CheckBox);
           // F.SetActive(true);
            reward.tag = "Item";
            reward.GetComponent<Item>().enabled = true;
        }
        else
        {
           
            checkBg.SetActive(true);
            Textchcek.text = "fail";
            StartCoroutine(Deley());
        }
    }
    void Update()
    {
         check = Position1.text + Position2.text + Position3.text + Position4.text + Position5.text + Position6.text + Position7.text + Position8.text;
        
    }
    private void OnMouseDown()
    {
        
    }
    IEnumerator Deley()
    {
        yield return new WaitForSeconds(5);
        checkBg.SetActive(false);
    }
}

