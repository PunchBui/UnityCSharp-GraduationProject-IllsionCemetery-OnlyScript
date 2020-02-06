using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public float speed = 1.0F;
    public float rotationSpeed = 100.0F;
    bool swap = true;
    public Vector3 jump;
    public GameObject pickupPanel;
    public float jumpForce = 2.0f;
    public GameObject Gameover;
    public Button ReSpawn;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Button BReSpawn = ReSpawn.GetComponent<Button>();
        BReSpawn.onClick.AddListener(GoToScene);
    }

    // Update is called once per frame
    void Update()
    {
        
            float translation = Input.GetAxis("Vertical") * speed;
            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            translation *= Time.deltaTime;
            rotation *= Time.deltaTime;
            transform.Translate(0, 0, translation);
            transform.Rotate(0, rotation, 0);
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            }
            if (translation != 0)
            {
                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        speed += 1f;
                        swap = false;
                    }
                    if (Input.GetKeyUp(KeyCode.LeftShift))
                    {
                        speed -= 1f;
                        swap = true;
                    }
            }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            pickupPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            pickupPanel.SetActive(false);
        }
    }
    void GoToScene()
    {
        Debug.Log("loading scene");
        SceneManager.LoadScene("SampleScene");
        float timeToLoadScene = 1;
        Invoke("GoToScene", timeToLoadScene);
    }
}
