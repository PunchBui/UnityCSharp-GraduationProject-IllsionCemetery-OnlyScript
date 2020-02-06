using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    // Start is called before the first frame update
    public int delay;
    void Start()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        if(delay == 0)
        {
            yield return new WaitForSeconds(3);
        }
        else
        {
            yield return new WaitForSeconds(delay);
        }
        Destroy(gameObject, GetComponent<ParticleSystem>().duration);
    }
}
