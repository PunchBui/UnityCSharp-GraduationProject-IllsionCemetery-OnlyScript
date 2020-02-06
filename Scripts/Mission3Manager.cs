using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission3Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gumare;
    public GameObject Quest;
    public Text QuestText;
    public Button QuestButton1;
    public GameObject guMareGood;
    bool once;
    public void GuMareAccept()
    {
        guMareGood.SetActive(true);
        Quest.SetActive(false);
        KManager.disableMouse();
    }
    public void QuestGuMare()
    {
        once = true;
        QuestText.text = "กุมารบาจเจ็บมาก คุณต้องการที่จะเอากุมารไปกับคุณหรือไม่";
        Quest.SetActive(true);
        KManager.enableMouse();
    }
}
