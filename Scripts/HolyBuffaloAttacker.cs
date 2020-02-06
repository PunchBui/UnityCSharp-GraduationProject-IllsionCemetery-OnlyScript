using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolyBuffaloAttacker : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject power;
    public GameObject powerHolyRobe;
    public void DoDmg()
    {
        IEnumerator AttackTime()
        {
            GameObject StartPosition = GameObject.FindWithTag("HolyBuffaloStartPoint").gameObject;
            yield return new WaitForSeconds(1);
            Instantiate(power, StartPosition.transform.position, StartPosition.transform.rotation);
        }
        StartCoroutine(AttackTime());
    }
    public void DoDmgHolyRobe()
    {
        IEnumerator AttackTime()
        {
            GameObject StartPosition = GameObject.FindWithTag("HolyBuffaloStartPoint").gameObject;
            yield return new WaitForSeconds(1);
            Instantiate(powerHolyRobe, StartPosition.transform.position, StartPosition.transform.rotation);
        }
        StartCoroutine(AttackTime());
    }
}
