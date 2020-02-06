using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public Animator anim;
    public float speed = 1.0F;
    public float rotationSpeed = 100.0F;
    bool swap = true;
    public Vector3 jump;
    public GameObject pickupPanel;
    public float jumpForce = 3.0f;
    public GameObject Gameover;
    public Button ReSpawn;
    public GameObject BombThrower;
    Rigidbody rb;
    [HideInInspector]
    public GameObject weaponManager;
    GameObject deleter;
    bool gotHitting;
    public Pickup hold;
    AudioManager audioMnger;
    bool running;
    bool bossStage;
    public bool floor2;
    public GameObject CutScenePa;
    public GameObject CameraMainAc;
    public GameObject shopUI;
    public GameObject GuMare;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Button BReSpawn = ReSpawn.GetComponent<Button>();
        BReSpawn.onClick.AddListener(GoToScene);
        weaponManager = GameObject.FindWithTag("WeaponManager");
        deleter = GameObject.FindWithTag("Inventory");
        KManager.enableMouse();
        audioMnger = GetComponent<AudioManager>();
        //[0] คือ BackGround [1] คือ Events
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (anim.GetBool("isDead") == false)
        {
                float translation = Input.GetAxis("Vertical") * speed;
                float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
                translation *= Time.deltaTime;
                rotation *= Time.deltaTime;
                transform.Translate(0, 0, translation);
                transform.Rotate(0, rotation, 0);
                if (Input.GetButtonDown("Jump"))
                {
                    Jumping();
                }
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    selectingPower();
                }
                if (translation != 0)
                {
                    if(!running)
                    {
                        audioMnger.ChangeSound("posture", "walk");
                    }
                    anim.SetBool("isIdle", false);
                    if (translation < 0)
                    {
                        anim.SetBool("isWalkingB", true);
                    }
                    else
                    {
                        if (swap)
                        {
                            if (hold!= null && hold.holding)
                            {
                                anim.SetBool("isWalkingCarrying", true);
                                anim.SetBool("isCarrying", false);
                            }
                            else
                            {
                                anim.SetBool("isWalking", true);
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.LeftShift))
                        {
                            anim.SetBool("isWalking", false);
                            anim.SetBool("isRunning", true);
                            speed += 1f;
                            swap = false;
                            audioMnger.ChangeSound("posture", "run");
                            running = true;
                        }
                        if (Input.GetKeyUp(KeyCode.LeftShift))
                        {
                            anim.SetBool("isRunning", false);
                            speed -= 1f;
                            swap = true;
                            audioMnger.StopSound("posture");
                            running = false;
                        }
                    }
                }
                else
                {
                    audioMnger.StopSound("posture");
                    anim.SetBool("isWalkingB", false);
                    anim.SetBool("isWalking", false);
                    if (hold != null && hold.holding)
                    {
                        anim.SetBool("isCarrying", true);
                        anim.SetBool("isWalkingCarrying", false);
                    }
                    else
                    {
                        anim.SetBool("isIdle", true);
                    }
                }
            //}
            ///life
            if (HealthBarScript.health <= 0)
            {

                anim.SetBool("isDead", true);
                anim.SetBool("isWalkingB", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isIdle", false);
                Gameover.SetActive(true);
                KManager.enableMouse();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            updateCenterPanel("เก็บ" + other.GetComponent<Item>().itemName);
        }
        else if(other.tag == "ShopPlace")
        {
            updateCenterPanel("เปิดร้านค้า");
        }
        else if (other.tag == "Pickable")
        {
            updateCenterPanel("ยกวัตถุ");
        }
        else if (other.tag == "door")
        {
            updateCenterPanel("เปิดประตู");
        }
        else if (other.tag == "Lift")
        {
            updateCenterPanel("ลงลิฟต์");
        }
        else if (other.tag == "PullDoor")
        {
            updateCenterPanel("ดันตู้ขวางปะตู");
        }
        else if (other.tag == "BossManager")
        {
            bossStage = true;
        }
        else if (other.tag == "Fuse")
        {
            updateCenterPanel("เอาฟิวส์ใส่ตู้");
        }
        else if (other.tag == "BtnPa")
        {
            pickupPanel.SetActive(true);
            pickupPanel.GetComponent<CenterPanel>().centerPanel.text = "กด E รัวๆเพื่อเปืดการทำงานกับดัก";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Item")
        {
            pickupPanel.SetActive(false);
        }
        else if (other.tag == "ShopPlace")
        {
            pickupPanel.SetActive(false);
        }
        else if (other.tag == "Pickable")
        {
            pickupPanel.SetActive(false);
        }
        else if (other.tag == "door")
        {
            pickupPanel.SetActive(false);
        }
        else if (other.tag == "Lift")
        {
            pickupPanel.SetActive(false);
        }
        else if (other.tag == "PullDoor")
        {
            pickupPanel.SetActive(false);
        }
        else if (other.tag == "Fuse")
        {
            pickupPanel.SetActive(false);
        }
        else if (other.tag == "BtnPa")
        {
            pickupPanel.SetActive(false);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Blood" && !gotHitting)
        {
            gotHitting = true;
            HealthBarScript.health -= 10f;
            StartCoroutine(HitDelay(2.18f));
            GotAtk();
        }
        if (other.tag == "BossSkill2" && !gotHitting)
        {
            gotHitting = true;
            HealthBarScript.health -= 30f;
            StartCoroutine(HitDelay(4f));
            GotAtk();
        }
    }
    void GoToScene()
    {
        HealthBarScript.health = 100f;
        anim.SetBool("isDead", false);
        anim.SetBool("isIdle", true);
        KManager.disableMouse();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 1:
                this.transform.position = GameObject.FindWithTag("Map1Manager").transform.position;
                GuMare.transform.position = GameObject.FindWithTag("Map1Manager").transform.position;
                break;
            case 2:
                if (floor2)
                {
                    CameraMainAc.SetActive(true);
                    CutScenePa.SetActive(false);
                    GameObject.FindWithTag("StartPaTop").SetActive(true);
                    StarPatop.F = true;
                    this.transform.position = GameObject.FindWithTag("floor2").transform.position;
                    GuMare.transform.position = GameObject.FindWithTag("floor2").transform.position;
                }
                else
                {
                    CameraMainAc.SetActive(true);
                    CutScenePa.SetActive(false);
                    this.transform.position = GameObject.FindWithTag("Map2Manager").transform.position;
                    GuMare.transform.position = GameObject.FindWithTag("Map2Manager").transform.position;
                }
                break;
            case 3:
                if (bossStage)
                {
                    this.transform.position = GameObject.FindWithTag("BossManager").transform.position;
                    GuMare.transform.position = GameObject.FindWithTag("BossManager").transform.position;
                }
                else
                {
                    CameraMainAc.SetActive(true);
                    CutScenePa.SetActive(false);
                    StratPa.checkStratPa = true;
                    StratPa.checkStratPaText = true;
                    this.transform.position = GameObject.FindWithTag("Map3Manager").transform.position;
                    GuMare.transform.position = GameObject.FindWithTag("Map3Manager").transform.position;
                }
                break;
        }
        Gameover.SetActive(false);
    }
    public void selectingPower()
    {
        int allWeapons = weaponManager.transform.childCount;
        for (int i = 0; i < allWeapons; i++)
        {
            if (weaponManager.transform.GetChild(i).gameObject.active)
            {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().type == "Weapon")
                {
                    usingPower("Weapon");
                    break;
                }
                else if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().type == "Bomb")
                {
                    usingPower("Bomb");
                    break;
                }
                else if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().type == "HolyBuffalo")
                {
                    usingPower("HolyBuffalo");
                    break;
                }
                else if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().type == "HolyRobe")
                {
                    usingPower("HolyRobe");
                    break;
                }
            }
        }
    }
    public void usingPower(string type)
    {
        Animator animCheck = gameObject.GetComponent<Animator>();
        if (type == "Weapon" && !animCheck.GetCurrentAnimatorStateInfo(0).IsName("Standing Melee Attack Backhand"))
        {
            if(GetComponent<HolyStickPower>().amount > 0)
            {
                anim.SetTrigger("isThrowing");
                this.GetComponent<HolyStickPower>().DoDmg();
            }
        }
        else if (type == "Bomb" && !animCheck.GetCurrentAnimatorStateInfo(0).IsName("Standing Melee Attack Backhand"))
        {
            anim.SetTrigger("isThrowing");
            BombThrower.GetComponent<granadeThrower>().ThrowGrenade();
        }
        else if (type == "HolyBuffalo" && !animCheck.GetCurrentAnimatorStateInfo(0).IsName("HolyBuffaloAttack"))
        {
            anim.SetTrigger("isHolyBuffaloing");
            this.GetComponent<HolyBuffaloAttacker>().DoDmg();
            StartCoroutine(deleterAction("HolyBuffalo"));
        }
        else if (type == "HolyRobe" && !animCheck.GetCurrentAnimatorStateInfo(0).IsName("HolyBuffaloAttack"))
        {
            anim.SetTrigger("isHolyBuffaloing");
            this.GetComponent<HolyBuffaloAttacker>().DoDmgHolyRobe();
            StartCoroutine(deleterAction("HolyRobe"));
        }
    }
    public IEnumerator deleterAction(string type)
    {
        yield return new WaitForSeconds(1);
        GetComponent<Inventory>().deleteItemSlot(type);
    }
    IEnumerator HitDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gotHitting = false;
    }
    public void updateCenterPanel(string msg)
    {
        pickupPanel.SetActive(true);
        pickupPanel.GetComponent<CenterPanel>().updateEvent(msg);
    }
    void Jumping()
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump 0"))
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            anim.SetTrigger("isJumping");
        }
    }
    public void HoldingUp()
    {
        anim.SetBool("isIdle", false);
        anim.SetBool("isCarrying", true);
    }
    public void Release()
    {
        anim.SetBool("isWalkingCarrying", false);
        anim.SetBool("isCarrying", false);
        anim.SetBool("isIdle", true);
    }
    public void GotAtk()
    {
        StartCoroutine(DelayAtk(1));
    }
    IEnumerator DelayAtk(int delay)
    {
        yield return new WaitForSeconds(delay);
        anim.SetTrigger("isGotAtked");
    }
}
