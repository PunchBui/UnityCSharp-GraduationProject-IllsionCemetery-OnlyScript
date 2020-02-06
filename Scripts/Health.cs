using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    Image healthBar;
    float maxHealth = 100f;
    public static float healthzom;
    // Update is called once per frame
    void Start()
    {
        healthBar = GetComponent<Image>();
        healthzom = maxHealth;
    }
  
    
    void Update()
    {
   
            healthBar.fillAmount = healthzom/ maxHealth;
        }
    }

