using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class CraftableItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject craftedItem;
    public int requiredItem;
    public GameObject[] item;
    private bool hovered;
    private GameObject player;
    public GameObject ItemManager;
    public GameObject Cover1;
    public GameObject Cover2;
    public GameObject Cover3;
    public CraftableItem[] CraftableItemAll = new CraftableItem[2];

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        updateAvailableItems();
    }
    public void Update()
    {
        if (hovered)
        {
            if (Input.GetMouseButtonDown(0))
            {
                CheckForRequiredItems();
            }
        }
    }
    public void CheckForRequiredItems()
    {
        int itemsInManager = ItemManager.transform.childCount;
        if(itemsInManager > 0)
        {
            int itemsFound = 0;
            for(int i = 0; i < itemsInManager; i++)
            {
                for(int j = 0; j < requiredItem; j++)
                {
                    if(ItemManager.transform.GetChild(i).GetComponent<Slot>().id == item[j].GetComponent<Item>().id)
                    {
                        itemsFound++;
                        break;
                    }
                    if(itemsFound == requiredItem)
                    {
                        break;
                    }
                }
                if (itemsFound == requiredItem)
                {
                    break;
                }
            }
            if (itemsFound >= requiredItem)
            {
                itemsFound = 0;
                for (int i = 0; i < itemsInManager; i++)
                {
                    for (int j = 0; j < requiredItem; j++)
                    {
                        if (ItemManager.transform.GetChild(i).GetComponent<Slot>().id == item[j].GetComponent<Item>().id)
                        {
                            ItemManager.transform.GetChild(i).GetComponent<Slot>().RemoveSlot();
                            itemsFound++;
                            break;
                        }
                        if (itemsFound == requiredItem)
                        {
                            break;
                        }
                    }
                    if (itemsFound == requiredItem)
                    {
                        break;
                    }
                }
                //GameObject spawnedItem = Instantiate(thisItem, player.transform.position, Quaternion.indentity);
                GameObject spawnedItem = Instantiate(craftedItem, new Vector3(0, 0, 0), Quaternion.identity);
                Item items = spawnedItem.GetComponent<Item>();
                player.GetComponent<Inventory>().AddItem(spawnedItem, items.id, items.type, items.description, items.icon);
                ItemManager.GetComponent<SlotHolder>().sortSlot();
                Cover1.gameObject.SetActive(true);
                Cover2.gameObject.SetActive(true);
                Cover3.gameObject.SetActive(true);
                for(int i=0;i<2;i++)
                {
                    CraftableItemAll[i].resetCover();
                }
            }
        }
    }
    public void resetCover()
    {
        Cover1.gameObject.SetActive(true);
        Cover2.gameObject.SetActive(true);
        Cover3.gameObject.SetActive(true);
    }
    public void updateAvailableItems()
    {
        int itemsInManager = ItemManager.transform.childCount;
        if (itemsInManager > 0)
        {
            int itemsFound = 0;
            for (int i = 0; i < itemsInManager; i++)
            {
                for (int j = 0; j < requiredItem; j++)
                {
                    if (ItemManager.transform.GetChild(i).GetComponent<Slot>().id == item[j].GetComponent<Item>().id)
                    {
                        itemsFound++;
                        if(ItemManager.transform.GetChild(i).GetComponent<Slot>().id == item[0].GetComponent<Item>().id)
                        {
                            Cover1.gameObject.SetActive(false);
                        }else if (ItemManager.transform.GetChild(i).GetComponent<Slot>().id == item[1].GetComponent<Item>().id)
                        {
                            Cover2.gameObject.SetActive(false);
                        }else if (ItemManager.transform.GetChild(i).GetComponent<Slot>().id == item[2].GetComponent<Item>().id)
                        {
                            Cover3.gameObject.SetActive(false);
                        }
                        break;
                    }
                }
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        hovered = false;
    }
}
