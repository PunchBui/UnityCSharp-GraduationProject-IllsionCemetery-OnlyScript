using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    public int id;
    public string type;
    public string description;
    public Sprite icon;
    public bool pickedUp;
    public static string typeOfPower;
    public int price;
    public string itemName;

    [HideInInspector]
    public bool equipped;
    [HideInInspector]
    public GameObject weapon;
    [HideInInspector]
    public GameObject weaponManager;
    public bool playerWeapon;
    HolyStickPower holystick;

    public void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");
        if (!playerWeapon)
        {
            int allWeapons = weaponManager.transform.childCount;
            for (int i = 0; i < allWeapons; i++)
            {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().id == id)
                {
                    weapon = weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
        holystick = GameObject.FindWithTag("Player").GetComponent<HolyStickPower>();
    }
    public void Update()
    {
        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                equipped = false;
            }
            if (equipped == false)
            {
                this.gameObject.SetActive(false);
                if(id == 0)
                {
                    holystick.ClosePanel();
                }
            }
        }
    }
    public void ItemUsage()
    {
        //weapon

        if (type == "Weapon" || type == "Bomb" || type == "HolyBuffalo" || type == "HolyRobe")
        {
            weapon.SetActive(true);
            weapon.GetComponent<Item>().equipped = true;
            typeOfPower = type;
        }
    }

}
