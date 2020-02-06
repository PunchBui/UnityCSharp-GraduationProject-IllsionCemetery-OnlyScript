using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    
    public GameObject inventory;
    public int allSlots;
    private int enabledSlots;
    public GameObject[] slot;
    public bool inventoryEnabled;
    GameObject itemPickedUp;
    static Animator anim;
    public GameObject slotHolder;
    public GameObject pickupPanel;
    public CraftableItem craftableitem1;
    public CraftableItem craftableitem2;
    GameObject weaponManager;
    void Start()
    {
        allSlots = 20;
        slot = new GameObject[allSlots];
        for(int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if(slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;
            }
        }
        anim = GetComponent<Animator>();
        weaponManager = GameObject.FindWithTag("WeaponManager");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            itemPickedUp = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            itemPickedUp = null;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
            if (inventoryEnabled == true)
            {
                inventory.SetActive(true);
                craftableitem1.updateAvailableItems();
                craftableitem2.updateAvailableItems();
                KManager.enableMouse();
            }
            else
            {
                inventory.SetActive(false);
                KManager.disableMouse();
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemPickedUp != null){
                anim.SetTrigger("isPicking");
                Item item = itemPickedUp.GetComponent<Item>();
                StartCoroutine(DelatPicking(itemPickedUp,item));
            }
        }
    }
    IEnumerator DelatPicking(GameObject itemPickedUp,Item item)
    {
        yield return new WaitForSeconds(1);
        AddItem(itemPickedUp, item.id, item.type, item.description, item.icon);
    }
    
    public void AddItem(GameObject itemObject, int itemid, string itemtype, string itemDescription, Sprite itemIcon)
    {
        for(int i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty)
            {
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = itemIcon;
                slot[i].GetComponent<Slot>().type = itemtype;
                slot[i].GetComponent<Slot>().id = itemid;
                slot[i].GetComponent<Slot>().description = itemDescription;
                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);
                pickupPanel.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();
                slot[i].GetComponent<Slot>().empty = false;
                itemPickedUp = null;
                return;
            }
        }
    }
    public void deleteItemSlot(string type)
    {
        int itemsInManager = slotHolder.transform.childCount;
        for (int i = 0; i < itemsInManager; i++)
        {
            if (slotHolder.transform.GetChild(i).GetComponent<Slot>().type == type)
            {
                slotHolder.transform.GetChild(i).GetComponent<Slot>().RemoveSlot();
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
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            if (slotHolder.transform.GetChild(i).GetComponent<Slot>().empty)
            {
                for (int j = i; j < slotHolder.transform.childCount; j++)
                {
                    if (!slotHolder.transform.GetChild(j).GetComponent<Slot>().empty)
                    {
                        slotHolder.transform.GetChild(j).SetSiblingIndex(i);
                        slotHolder.transform.GetChild(j).GetComponent<Slot>().RemoveSlot();
                        break;
                    }
                }
            }
        }
    }
}
