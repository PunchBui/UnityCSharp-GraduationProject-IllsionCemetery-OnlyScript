using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamploop : MonoBehaviour
{
    public GameObject lamp;

    void Start()
    {
        StartCoroutine(looplamp());
    }

    IEnumerator looplamp()
    {
        while (true)
        {

            yield return new WaitForSeconds(2);
            lamp.SetActive(true);
            Debug.Log("on");
            StartCoroutine(lampOff());
        }
    }
    IEnumerator lampOff()
    {
        while (true)
        {
            yield return new WaitForSeconds(randomlooplamp());
            lamp.SetActive(false);
            Debug.Log("off");
        }
    }
    public float randomlooplamp()
    {

        return (float)Random.Range(1f, 4f);
    }
}
