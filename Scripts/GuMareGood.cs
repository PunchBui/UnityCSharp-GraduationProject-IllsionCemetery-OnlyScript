using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
public class GuMareGood : MonoBehaviour
{
    public Transform player;
    Animator anim;
   // public GameObject Powerpee;
    GameObject go;
    public bool GotHitting;
    public bool Dead;
    public bool staying = false;
    GameObject coin;
    public static bool have  = false ;
    private void Start()
    {
        have = true;
        Debug.Log(have);
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
       if (Vector3.Distance(player.position, this.transform.position) < 100)
            {
            Vector3 direction = player.position - this.transform.position;
            direction.y = 0;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                          Quaternion.LookRotation(direction), 0.1f);
                anim.SetBool("isIdle", false);
            if(direction.magnitude > 30f)
            {
                this.transform.position = player.position;
                GameObject.FindWithTag("GuMareGood").GetComponent<GuMareGood>().player = GameObject.FindWithTag("GuMarePlace").transform;
                GameObject.FindWithTag("GuMareRangeChecker").GetComponent<rangeChecker>().need = true;
            }
                if (direction.magnitude > 2f)
                 {
                    this.transform.Translate(0, 0, 0.05f);
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isAttacking", false);
                }
                else
                {
                    if(player.tag == "Enemy")
                    {
                        anim.SetBool("isAttacking", true);
                    }
                    else
                    {
                        anim.SetBool("isIdle", true);
                    }
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isWalking", false);
                }
        }
    }
}
