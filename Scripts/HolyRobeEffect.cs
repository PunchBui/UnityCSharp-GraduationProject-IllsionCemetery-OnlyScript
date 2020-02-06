using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class HolyRobeEffect : MonoBehaviour
{
    public bool playerStay = false;
    PlayableDirector playableDirector;
    bool delete = false;
    void Start()
    {
        StartCoroutine(Counter());
        playableDirector = GetComponent<PlayableDirector>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!playerStay)
            {
                playerStay = true;
                StartCoroutine(Healer());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerStay = false;
        }
    }
    IEnumerator Healer()
    {
        while (playerStay)
        {
            if (HealthBarScript.health <= 100)
            {
                HealthBarScript.health += 5f;
            }
            else
            {
                playerStay = false;
            }
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator Counter()
    {
        yield return new WaitForSeconds(10);
        playableDirector.Play();
        delete = true;
    }
    private void Update()
    {

        if ((playableDirector.state == PlayState.Paused) && delete)
        {
            Destroy(gameObject);
        }
    }
}
