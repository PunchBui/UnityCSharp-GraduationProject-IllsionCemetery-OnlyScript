using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float delay = 3f;
    public float radius = 5f;
    public float force = 700f;
    public GameObject explosion;
    public GameObject flame;
    float countdown;
    bool hasExloded = false;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <=0f && !hasExloded)
        {
            Exploder();
            hasExloded = true;
        }
    }
    void Exploder()
    {
        Debug.Log("bomb");
        Instantiate(explosion, transform.position, transform.rotation);
        Instantiate(flame, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(force, transform.position,radius);
            }
            GameObject go = nearbyObject.gameObject;
            if (go.tag == "Enemy")
            {
                go.transform.Find("HealthBarzombie").gameObject.transform.Find("HealthBar").GetComponent<HealthBarZombie>().GotAttacked("Bomb");
            }
        }
        Destroy(gameObject);
    }
}
