using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StratPa : MonoBehaviour
{
    
    public static bool checkStratPa = true;
    public static bool checkStratPaText = true;
    public string text;
    public GameObject tuterialPanel;
    public Text textPanel;
    public GameObject Pa;
    public GameObject Camera ;
    public GameObject spawnPoints;
    public Button ped;
    public AudioClip AudioClip;
    public AudioSource AudioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        Button Ped = ped.GetComponent<Button>();
        Ped.onClick.AddListener(PedButton);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player") && checkStratPaText)
        {
            checkStratPaText = false;
                textPanel.text = text;
                tuterialPanel.SetActive(true);
                KManager.enableMouse();
            }
        
    }
    void PedButton()
    {
        if (StratPa.checkStratPa)
        {
            AudioSource.clip = AudioClip;
            AudioSource.Play();
            Camera.SetActive(true);
            checkStratPa = false;
            Instantiate(Pa, spawnPoints.transform.position, spawnPoints.transform.rotation);
            StartCoroutine(Delay());
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3);
        Camera.SetActive(false);
    }
    void Update()
    {
         if (checkStratPa)
        {
             AudioSource.Stop();
        }
    }

}


