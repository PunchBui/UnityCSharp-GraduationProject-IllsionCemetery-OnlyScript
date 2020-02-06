using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class zombie : MonoBehaviour
{
    float Hp = 100f;
    public Image healthBar;
    float maxHealth = 100f;
    public GameObject countzombie;
    Animator anim;
    bool checkD = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        healthBar.fillAmount = Hp / maxHealth;
        
        if (Hp <= 0f && !checkD)
        {
            Debug.Log("out");
            anim.SetBool("isDead", true);
            countzombie.SetActive(false);
            StartCoroutine(Destroy());
            checkD = true;
        }
    }
    void OnParticleCollision(GameObject other)
    {
            Hp -= ramdom();
            Debug.Log("Particle Collision!");
    }
    float ramdom()
    {
        return Random.Range(3f, 7f);
    }

    public static void hit()
    {
         HealthBarScript.health -= 5f;
         Debug.Log("-10");
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);

    }
}