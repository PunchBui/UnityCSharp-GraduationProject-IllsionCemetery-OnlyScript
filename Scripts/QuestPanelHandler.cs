using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public Text questText;
    public Button questButton;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void setingQuestPanel()
    {
        string text = "";
        questText.GetComponent<Text>().text = text;
    }
}
