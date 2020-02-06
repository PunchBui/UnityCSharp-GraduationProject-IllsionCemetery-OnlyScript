using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HolyStickPower : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject power;
    Inventory deleter;
    GameObject slotHolder;
    public GameObject HolyWaterAnountPanel;
    public Text HolyWaterAmount;
    public int amount = 0;
    private void Start()
    {
        deleter = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        slotHolder = deleter.slotHolder;
    }
    public void DoDmg()
    {
        IEnumerator AttackTime()
        {
            GameObject StartPosition = GameObject.FindWithTag("PowerStartPoint").gameObject;
            yield return new WaitForSeconds(1);
            Instantiate(power, StartPosition.transform.position, StartPosition.transform.rotation);
        }
        StartCoroutine(AttackTime());
        UpdatePanel();
    }
    public void CheckHolyWater()
    {
            int itemsInManager = slotHolder.transform.childCount;
            for (int i = 0; i < itemsInManager; i++)
            {
                if (slotHolder.transform.GetChild(i).GetComponent<Slot>().type == "Water")
                {
                    amount += 20;
                    HolyWaterAmount.text = "X " + amount;
                    deleter.deleteItemSlot("Water");
                    break;
                }
            }
    }
    public void OpenPanel()
    {
        HolyWaterAmount.text = "X " + amount;
        HolyWaterAnountPanel.SetActive(true);
    }
    public void ClosePanel()
    {
        HolyWaterAnountPanel.SetActive(false);
    }
    public void UpdatePanel()
    {
        if(amount > 0)
        {
            amount -= 1;
            HolyWaterAmount.text = "X " + amount;
        }
    }
}
