using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPlace : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shopUI;
    bool near;
    AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        shopUI = GameObject.FindWithTag("Player").GetComponent<PlayerControl>().shopUI;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (near)
            {
           
                shopUI.SetActive(true);
                audio.Play();
                KManager.enableMouse();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            near = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            near = false;
            shopUI.SetActive(false);
            KManager.disableMouse();
            audio.Stop();
        }
    }
}
