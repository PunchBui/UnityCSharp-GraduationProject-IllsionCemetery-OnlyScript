using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarPatop : MonoBehaviour
{
    GameObject Pa;
    public GameObject spawnPoints;
    public GameObject hazard;
    public GameObject dooropen;
    public GameObject doorcloed;
    public static bool F = true ;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            if (F)
            {
                F = false;
                StartCoroutine(delayDoor());
                Instantiate(hazard, spawnPoints.transform.position, spawnPoints.transform.rotation);

                
                Debug.Log("Start");
            }
        }

    }
    IEnumerator delayDoor()
    {
        yield return new WaitForSeconds(5);
            dooropen.SetActive(false);
            doorcloed.SetActive(true);
    }
}
