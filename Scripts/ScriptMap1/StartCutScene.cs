using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject CutScene;
    public GameObject DoorS;
    public GameObject DoorNo;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            DoorS.SetActive(false);

            DoorNo.SetActive(true);
            CutScene.SetActive(true);
            Destroy(gameObject);
        }    
    }

}
