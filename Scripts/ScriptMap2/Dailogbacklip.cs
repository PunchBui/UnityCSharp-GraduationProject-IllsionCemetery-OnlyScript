using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dailogbacklip : MonoBehaviour
{
    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    public GameObject F1;
    public GameObject F2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }
    IEnumerator Type()
    {
        if (F1.active && F2.active)
        foreach (char letter in sentences[1].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        else 
        {
            foreach (char letter in sentences[0].ToCharArray())
            {
                textDisplay.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

    }
}
