using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    // Start is called before the first frame update
    public GameObject item;
    public int id;
    public string type;
    public string description;
    public Sprite icon;
    public Transform slotIconGO;
    public int price;
    Inventory iv;
    public bool empty = true;
    void Start()
    {
        slotIconGO = transform.GetChild(0);
        iv = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }
    private void Update()
    {
        if(icon != null)
        {
            slotIconGO.GetComponent<Image>().sprite = icon;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!empty)
        {
            CheckSoulsAmount();
        }
        else
        {
            //empty
        }
    }
    void CheckSoulsAmount()
    {
        CoinManager coinGO = GameObject.FindWithTag("CoinManager").GetComponent<CoinManager>();
        int coinAmount = coinGO.coin;
        if (coinAmount - price >= 0)
        {
            coinGO.updateCoin(-price);
            PurchaseItem();
            RemoveSlot();
        }
        else
        {
            //moremoney
        }
    }
    public void PurchaseItem()
    {
        GameObject spawnedItem = Instantiate(item, new Vector3(0, 0, 0), Quaternion.identity);
        Item items = spawnedItem.GetComponent<Item>();
        iv.AddItem(spawnedItem, items.id, items.type, items.description, items.icon);
    }
    public void RemoveSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = null;
        id = 0;
        type = null;
        description = null;
        item = null;
        icon = null;
        empty = true;
        price = 0;
        slotIconGO.GetComponent<Image>().sprite = null;
    }
}
