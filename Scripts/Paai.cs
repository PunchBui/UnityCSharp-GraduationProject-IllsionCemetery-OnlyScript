using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Paai : MonoBehaviour
{
    public NavMeshAgent agent;
    Transform taget;

    void Start()
    {
      
        taget = GameObject.FindWithTag("Player").transform;
    }
    void Update()
    {
         agent.destination = taget.position;
    
    }
}
