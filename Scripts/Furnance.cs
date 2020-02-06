using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnance : MonoBehaviour
{
    public GameObject reward;
    bool corpse;
    bool bomb;
    bool done;
    private void OnTriggerEnter(Collider other)
    {
        if (!done)
        {
            if (other.name == "corpse")
            {
                corpse = true;
                checkDone();
            }
            if (other.tag == "Item")
            {
                if (other.GetComponent<Item>().type == "Bomb")
                {
                    bomb = true;
                    checkDone();
                }
            }
        }
    }
    void checkDone()
    {
        if(corpse && bomb)
        {
            reward.SetActive(true);
            done = true;
        }
    }
}
