using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject[] shopslot;
    GameObject shopHolder;
    public GameObject[] items = new GameObject[9];
    void Start()
    {
        shopHolder = GameObject.FindWithTag("ShopHolder");
        randomItems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void randomItems()
    {
        for(int i=0;i<shopHolder.transform.childCount;i++)
        {
            int random = Random.Range(0, items.Length);
            shopHolder.transform.GetChild(i).GetComponent<ShopSlot>().item = items[random].gameObject;
            shopHolder.transform.GetChild(i).GetComponent<ShopSlot>().id = items[random].GetComponent<Item>().id;
            shopHolder.transform.GetChild(i).GetComponent<ShopSlot>().type = items[random].GetComponent<Item>().type;
            shopHolder.transform.GetChild(i).GetComponent<ShopSlot>().description = items[random].GetComponent<Item>().description;
            shopHolder.transform.GetChild(i).GetComponent<ShopSlot>().icon = items[random].GetComponent<Item>().icon;
            shopHolder.transform.GetChild(i).GetComponent<ShopSlot>().icon = items[random].GetComponent<Item>().icon;
            shopHolder.transform.GetChild(i).GetComponent<ShopSlot>().price = items[random].GetComponent<Item>().price;
            shopHolder.transform.GetChild(i).GetComponent<ShopSlot>().empty = false;
            shopHolder.transform.GetChild(i).Find("Price").GetComponent<Text>().text = items[random].GetComponent<Item>().price.ToString();
        }
    }
    public void purchessRandomItems()
    {
        int reRollPrice = 2;
        CoinManager coinGO = GameObject.FindWithTag("CoinManager").GetComponent<CoinManager>();
        int coinAmount = coinGO.coin;
        if (coinAmount >= reRollPrice)
        {
            coinGO.updateCoin(-reRollPrice);
            randomItems();
        }
    }
}
