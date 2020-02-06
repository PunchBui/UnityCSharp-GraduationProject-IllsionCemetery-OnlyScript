using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarZombie : MonoBehaviour
{
    Image healthBar;
    public float maxHealth = 100f;
    public float health = 0;
    void Start()
    {
        healthBar = GetComponent<Image>();
        health = maxHealth;
    }
    void Update()
    {
    }
    public void GotAttacked(string type)
    {
        float bomb = 25f;
        float weapon = 35f;
        float buffalo = 75f;
        float HolyRobe = 10f;
        float GuMare = 10f;
        Debug.Log("got dmg");
        if (type == "Bomb")
        {
            Debug.Log("bomb");
            health -= bomb;
            healthBar.fillAmount = health / maxHealth;
        }
        else if(type == "Weapon")
        {
            health -= weapon;
            healthBar.fillAmount = health / maxHealth;
        }else if(type == "buffalo")
        {
            health -= buffalo;
            healthBar.fillAmount = health / maxHealth;
        }
        else if (type == "HolyRobe")
        {
            Debug.Log("HIT");
            health -= HolyRobe;
            healthBar.fillAmount = health / maxHealth;
        }
        else if (type == "GuMare")
        {
            health -= GuMare;
            healthBar.fillAmount = health / maxHealth;
        }
    }
}
