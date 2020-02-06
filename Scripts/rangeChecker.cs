using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangeChecker : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject Enemy;
    public bool need = true;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy" && need)
        {
            GameObject.FindWithTag("GuMareGood").GetComponent<GuMareGood>().player = other.transform;
            need = false;
        }
    }
}
