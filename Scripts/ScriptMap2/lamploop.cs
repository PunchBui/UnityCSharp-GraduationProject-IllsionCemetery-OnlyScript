using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lamploop : MonoBehaviour
{
    public Light lamp;
    void Start()
    {
        StartCoroutine(lampIncrease());
    }
    IEnumerator lampIncrease()
    {
        if(lamp.intensity != 0)
        {
            lamp.intensity -= 1f;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(lampIncrease());
        }
        else
        {
            StartCoroutine(lampDecrease());
        }
    }
    IEnumerator lampDecrease()
    {
        if (lamp.intensity != 10)
        {
            lamp.intensity += 1f;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(lampDecrease());
        }
        else
        {
            StartCoroutine(lampIncrease());
        }
    }
}



