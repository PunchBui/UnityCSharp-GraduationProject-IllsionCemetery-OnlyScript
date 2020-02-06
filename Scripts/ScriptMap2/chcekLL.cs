using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class chcekLL : MonoBehaviour
{
    public GameObject liftPanel;
    public Text text;
    public GameObject CutScenelip;
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                liftPanel.SetActive(true);
                KManager.enableMouse();
            }
        }
    }
    public void panel()
    {
        if (GameObject.Find("Fusedback").GetComponent<checkFusedbacklip>().checkEz)
        {
            passingMap();
        }
        else
        {
            text.text = "ลิฟไม่ทำงาน ฟิวส์ยังไม่ครบ ลองเช็คที่ตู้ไฟข้างหลังลิฟดู";
        }
    }
    public void exit()
    {

        liftPanel.SetActive(false);
        KManager.disableMouse();
    }
    public void passingMap()
    {
        KManager.disableMouse();
        liftPanel.SetActive(false);
        text.text = "กำลังลงไปชั้นใต้ดิน...";
        CutScenelip.SetActive(true);

        StartCoroutine(nextScene());

    }
    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(4);
        TimedSpawn.PassScene = true ;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        GameObject.FindWithTag("Player").transform.position = new Vector3(-24.24f, 2.22774f, 93.561f);
    }
}
