﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mis1_4 : MonoBehaviour
{
    public GameObject item1;
    // Start is called before the first frame update
    void OnMouseDown()
    {
        transform.Rotate(0, 30, 0);
        item1.transform.Rotate(0, 30, 0);

    }
}
