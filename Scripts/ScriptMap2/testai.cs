using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class testai : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] taget;
    int i ;
    void Start()
    {
        i = 0;
        agent.destination = taget[i].position;
        Debug.Log(taget.Length);
            }

    // Update is called once per frame
    void Update()
    {
        
            if (Vector3.Distance(taget[i].position, this.transform.position) < 1)
            {
                i++;
            if (i == taget.Length)
            {
                Debug.Log(i + " = " + (taget.Length - 1));
                i = 0;
            }
            agent.destination = taget[i].position;
            }
           
    
        
    }
    
}
