using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject Descript;
    public GameObject item;
    public int id;
    public string type;
    public string description;
    public bool empty;
    public Sprite icon;
    public Text des_text;
    Transform slotIconGO;
    HolyStickPower holystick;

    public void OnPointerClick(PointerEventData eventData)
    {
        UseItem();
    }
    private void Start()
    {
        slotIconGO = transform.GetChild(0);
        holystick = GameObject.FindWithTag("Player").GetComponent<HolyStickPower>();
    }
    public void UpdateSlot()
    {
        slotIconGO = transform.GetChild(0);
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
    public void RemoveSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = null;
        id = 0;
        type = null;
        description = null;
        item = null;
        icon = null;
        if (transform.childCount > 0 && !empty)
        {
             Destroy(transform.GetChild(1).gameObject);
        }
        empty = true;
    }
    public void UseItem()
    {
        if(id == 1)
        {
            holystick.CheckHolyWater();
        }
        if (id == 0)
        {
            holystick.OpenPanel();
        }
        if (item != null){
            item.GetComponent<Item>().Start();
            item.GetComponent<Item>().ItemUsage();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Descript.SetActive(true);
        des_text.text = GetComponent<Slot>().description;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Descript.SetActive(false);
    }
}