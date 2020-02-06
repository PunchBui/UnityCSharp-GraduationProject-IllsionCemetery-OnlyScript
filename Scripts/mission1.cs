using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mission1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject questCam;
    GameObject mainCam;
    GameObject reward;
    public bool done;
    void Start()
    {
        mainCam = GameObject.FindWithTag("mainCam");
        reward = transform.Find("Diary").gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !done)
        {
            mainCam.SetActive(false);
            questCam.SetActive(true);
            KManager.enableMouse();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && !done)
        {
            mainCam.SetActive(true);
            questCam.SetActive(false);
            KManager.disableMouse();
        }
    }
    public void doneMission()
    {
        reward.SetActive(true);
        done = true;
        mainCam.SetActive(true);
        questCam.SetActive(false);
        KManager.disableMouse();
    }
}
