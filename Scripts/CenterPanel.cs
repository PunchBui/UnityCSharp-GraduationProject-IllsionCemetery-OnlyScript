using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenterPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Text centerPanel;
    public void updateEvent(string msg)
    {
        centerPanel.text = "กด E เพื่อ " + msg;
    }
}
