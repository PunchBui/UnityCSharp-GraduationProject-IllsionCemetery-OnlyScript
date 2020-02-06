using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CheckCutScenePull : MonoBehaviour
{

    public GameObject CameralookforLocker;
    
    public GameObject Cutscene;
  
    // Start is called before the first frame update

    void Start()
    {
    }
   

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
             
                CameralookforLocker.SetActive(true);
                
                Cutscene.SetActive(true);
            }
        }
    }
}
