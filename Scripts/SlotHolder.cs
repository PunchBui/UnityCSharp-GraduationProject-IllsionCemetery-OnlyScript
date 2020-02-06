using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ItemManager;
    [HideInInspector]
    public GameObject weaponManager;
    void Start()
    {
        weaponManager = GameObject.FindWithTag("WeaponManager");
    }
    public void deleteItemSlot(string type)
    {
        int itemsInManager = ItemManager.transform.childCount;
        for (int i = 0; i < itemsInManager; i++)
        {
            if (ItemManager.transform.GetChild(i).GetComponent<Slot>().type == type)
            {
                ItemManager.transform.GetChild(i).GetComponent<Slot>().RemoveSlot();
                break;
            }
        }
        int allWeapons = weaponManager.transform.childCount;
        for (int i = 0; i < allWeapons; i++)
        {
            if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().type == type)
            {
                weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().equipped = false;
                weaponManager.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        sortSlot();
    }
    public void sortSlot()
    {
        for(int i = 0; i < ItemManager.transform.childCount; i++)
        {
            if (ItemManager.transform.GetChild(i).GetComponent<Slot>().empty)
            {
                for (int j = i; j < ItemManager.transform.childCount; j++)
                {
                    if (!ItemManager.transform.GetChild(j).GetComponent<Slot>().empty)
                    {
                        ItemManager.transform.GetChild(j).SetSiblingIndex(i);
                        ItemManager.transform.GetChild(j).GetComponent<Slot>().RemoveSlot();
                        break;
                    }
                }
            }
        }
    }
}
