using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public int coin;
    public Text CoinText;
    void Start()
    {
        coin = 0;
    }
    
    void Update()
    {
       
    }
    public void updateCoin(int amount)
    {
        coin += amount;
        CoinText.text = coin.ToString();
    }
}
