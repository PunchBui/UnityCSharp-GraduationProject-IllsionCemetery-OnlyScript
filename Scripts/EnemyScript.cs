using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;
public class EnemyScript : MonoBehaviour
{
    public AudioClip AudioClipIdle ;
    public AudioClip AudioClipDead ;
    public AudioSource AudioSourceIdle ;
    public AudioSource AudioSourceDead ;
    public Transform player;
    public Animator anim;
   // public GameObject Powerpee;
    public NavMeshAgent agent;
    public Transform taget;
    PlayableDirector playableDirector ;
    public GameObject healthbar;
    GameObject go;
    public bool GotHitting;
    public bool Dead;
    public bool staying = false;
    GameObject coin;
    bool gum;
    private void Start()
    {
        
        anim = GetComponent<Animator>();
        go = this.transform.Find("HealthBarzombie").gameObject.transform.Find("HealthBar").gameObject;
        playableDirector = GetComponent<PlayableDirector>();
        player = GameObject.FindWithTag("Player").transform;
        taget = player;
        coin = GameObject.FindWithTag("CoinManager");
         AudioSourceIdle.clip = AudioClipIdle;
         AudioSourceIdle.Play();
    }
    private void Update()
    {
        
        if (anim.GetBool("isDead") == false)
        {
          
            if (Vector3.Distance(player.position, this.transform.position) < 100)
            {
                Vector3 direction = player.position - this.transform.position;
                direction.y = 0;
                this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                          Quaternion.LookRotation(direction), 0.0f);

                // direction.y = 0;
                anim.SetBool("isIdle", false);
                if (direction.magnitude > 2f)
                {
                    //this.transform.Translate(0, 0, 0.02f);
                    agent.destination = taget.position;
                    anim.SetBool("isWalking", true);
                    anim.SetBool("isAttacking", false);
                }
                else
                {

                    anim.SetBool("isAttacking", true);
                    anim.SetBool("isWalking", false);

                }
            }
            else
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isAttacking", false);
            }
            checkDead();
        }
        else
        {
            if (playableDirector.state == PlayState.Paused)
            {
                Destroy(gameObject);
            }
        }
    }
    public void checkDead()
    {
        if(go.GetComponent<HealthBarZombie>().health <= 0)
        {
            AudioSourceIdle.Stop();
            AudioSourceDead.clip = AudioClipDead;
            AudioSourceDead.Play();
            notifyGuMare();
            Dead = true;
            coin.GetComponent<CoinManager>().updateCoin(1);
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isDead", true);
            if (playableDirector != null)
            {
                healthbar.SetActive(false);
                Component[] boxCols = this.GetComponents<BoxCollider>();
                foreach(Component boxCol in boxCols)
                {
                    Destroy(boxCol);
                }
                playableDirector.Play();
            }
            TimedSpawn.countkillzombie++;
            if(name == "GuMarePreFab 1")
            {
                GameObject.FindWithTag("map1mis3Manager").GetComponent<Mission3Manager>().QuestGuMare();
            }
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !Dead){
            HealthBarScript.health -= 10f;
            player.GetComponent<PlayerControl>().GotAtk();
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
