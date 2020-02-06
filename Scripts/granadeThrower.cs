using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granadeThrower : MonoBehaviour
{
    public float throwForce;
    public GameObject grenadePrefab;
    public PlayerControl player;
    [HideInInspector]
    public GameObject weaponManager;
    void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }

    public void ThrowGrenade()
    {
        StartCoroutine(AttackTime());
        StartCoroutine(player.deleterAction("Bomb"));
    }
    IEnumerator AttackTime()
    {
        yield return new WaitForSeconds(1);
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce, ForceMode.VelocityChange);
    }
}
