using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class BossScript : MonoBehaviour
{
    Transform player;
    Animator anim;
   // public GameObject Powerpee;
    Transform taget;
    public GameObject healthbar;
    GameObject go;
    public bool GotHitting;
    public bool Dead;
    public bool staying = false;
    bool gum;
    public GameObject[] powerPoint;
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    bool atking;
    AudioSource audio;
    public AudioClip skill;
    public AudioClip dead;
    bool firstSkill;
    public GameObject CutsceneEnd;
    private void Start()
    {
        anim = GetComponent<Animator>();
        go = this.transform.Find("HealthBarzombie").gameObject.transform.Find("HealthBar").gameObject;
        player = GameObject.FindWithTag("Player").transform;
        taget = player;
        go.GetComponent<HealthBarZombie>().maxHealth = 1000f;
        go.GetComponent<HealthBarZombie>().health = 1000f;
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (anim.GetBool("isDead") == false)
        {
            if (Vector3.Distance(player.position, this.transform.position) < 100)
            {
                Vector3 lookVector = player.transform.position - transform.position;
                lookVector.y = transform.position.y;
                Quaternion rot = Quaternion.LookRotation(lookVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);
                if (!atking)
                {
                    randomSkill();
                    StartCoroutine(AtkDelay());
                }
            }
            else
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isAttacking", false);
            }
            checkDead();
        }
    }
    void randomSkill()
    {
        if (!firstSkill)
        {
            Powerskill3();
            firstSkill = true;
        }
        else
        {
            int random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    Powerskill1();
                    break;
                case 1:
                    Powerskill2();
                    break;
                case 2:
                    Powerskill3();
                    break;
            }
        }
        audio.Play();
    }
    void Powerskill1()
    {
        atking = true;
        anim.SetBool("isIdle", false);
        anim.SetTrigger("isSkill2");
        StartCoroutine(InsidePowerPoint(skill1,2));
        anim.SetBool("isIdle", true);
    }
    void Powerskill2()
    {
        atking = true;
        anim.SetBool("isIdle", false);
        anim.SetTrigger("isSkill3");
        StartCoroutine(InsidePowerPoint(skill2, 2));
        anim.SetBool("isIdle", true);
    }
    void Powerskill3()
    {
        atking = true;
        anim.SetBool("isIdle", false);
        anim.SetTrigger("isSkill1");
        for (int i = 0; i < 1; i++)
        {
            Instantiate(skill3, powerPoint[i].transform.position, powerPoint[i].transform.rotation);
        }
        anim.SetBool("isIdle", true);
    }
    IEnumerator AtkDelay()
    {
        yield return new WaitForSeconds(7);
        atking = false;
    }
    IEnumerator InsidePowerPoint(GameObject power,int delay)
    {
        yield return new WaitForSeconds(delay);
        foreach(GameObject powerP in powerPoint)
        {
            Instantiate(power, powerP.transform.position, powerP.transform.rotation);
        }
    }
    public void checkDead()
    {
        if(go.GetComponent<HealthBarZombie>().health <= 0)
        {
            notifyGuMare();
            CutsceneEnd.SetActive(true);
            Dead = true;
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isDead", true);
            TimedSpawn.countkillzombie++;
            audio.clip = dead;
            audio.Play();
            Destroy(gameObject);
          //  StartCoroutine(EndGame());
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Dead){
            HealthBarScript.health -= 10f;
        }
        if(other.tag == "PowerHolyRobe" && !Dead && !staying)
        {
            staying = true;
            StartCoroutine(DmgHolyBuffalo());
        }
        if (other.tag == "GuMareGood")
        {
            gum = true;
            StartCoroutine(DmgGuMare());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PowerHolyRobe" && !Dead)
        {
            staying = false;
        }
        if (other.tag == "GuMareGood")
        {
            gum = false;
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Power" && !GotHitting)
        {
            GotHitting = true;
            go.GetComponent<HealthBarZombie>().GotAttacked("Weapon");
            StartCoroutine(HitDelay(1));
        } else if (other.tag == "PowerHolyBuffalo" && !GotHitting)
        {
            GotHitting = true;
            go.GetComponent<HealthBarZombie>().GotAttacked("buffalo");
            StartCoroutine(HitDelay(3));
        }
    }
    IEnumerator DmgHolyBuffalo()
    {
        while (staying)
        {
            if (go.GetComponent<HealthBarZombie>().health >= 0f)
            {
                go.GetComponent<HealthBarZombie>().GotAttacked("HolyRobe");
                yield return new WaitForSeconds(1);
            }
            else
            {
                staying = false;
            }
        }
    }
    IEnumerator DmgGuMare()
    {
        while (gum)
        {
            if (go.GetComponent<HealthBarZombie>().health >= 0f)
            {
                go.GetComponent<HealthBarZombie>().GotAttacked("GuMare");
                yield return new WaitForSeconds(1);
            }
            else
            {
                gum = false;
            }
        }

    }
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(9);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    IEnumerator HitDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GotHitting = false;
    }
    public void notifyGuMare()
    {
        if (GameObject.FindWithTag("GuMareGood") != null)
        {
            GameObject.FindWithTag("GuMareGood").GetComponent<GuMareGood>().player =  GameObject.FindWithTag("GuMarePlace").transform;
            GameObject.FindWithTag("GuMareRangeChecker").GetComponent<rangeChecker>().need = true;
        }
    }
}
