using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mis1_3 : MonoBehaviour
{

    public GameObject item2;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        transform.Rotate(0, 30, 0);
        item2.transform.Rotate(0, 30, 0);

    }
}
