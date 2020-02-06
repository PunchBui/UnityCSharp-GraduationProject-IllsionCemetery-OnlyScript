using UnityEngine;
using System.Collections;
public class Pickup : MonoBehaviour
{
    GameObject item;
    Transform guide;
    public GameObject pickupPanel;
    bool near;
    public bool holding;
    PlayerControl player;
    void Start()
    {
        item = this.gameObject;
        guide = GameObject.FindWithTag("PickupHolder").transform;
        item.GetComponent<Rigidbody>().useGravity = true;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (holding)
            {
                Release();
            }
            else
            {
                if (near)
                {
                    HoldingUp();
                }
            }
        }
    }
    void HoldingUp()
    {
        holding = true;
        pickupPanel.SetActive(false);
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().hold = this;
        player.HoldingUp();
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().isKinematic= true;
        transform.position = guide.transform.position;
        transform.rotation = guide.transform.rotation;
        transform.parent = guide.transform;
    }
    void Release()
    {
        holding = false;
        GameObject.FindWithTag("Player").GetComponent<PlayerControl>().hold = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
        transform.parent = null;
        transform.position = guide.transform.position;
        player.Release();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            near = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            near = false;
        }
    }
}
