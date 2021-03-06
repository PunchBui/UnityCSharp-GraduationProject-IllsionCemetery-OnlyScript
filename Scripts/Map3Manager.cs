﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map3Manager : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.transform.position = this.transform.position;
        player.GetComponent<PlayerControl>().GuMare.transform.position = this.transform.position;
        player.transform.localScale -= new Vector3(0.4f, 0.4f, 0.4f);
        player.GetComponent<PlayerControl>().GuMare.transform.localScale -= new Vector3(0.4f, 0.4f, 0.4f);
        player.GetComponent<PlayerControl>().speed = 5F;
        GameObject.FindWithTag("Player").GetComponent<AudioManager>().ChangeSound("BG", "Map3BG");
        if (GameObject.FindWithTag("GuMareGood") != null)
        {
            GameObject.FindWithTag("GuMareGood").GetComponent<GuMareGood>().player = GameObject.FindWithTag("GuMarePlace").transform;
            GameObject.FindWithTag("GuMareRangeChecker").GetComponent<rangeChecker>().need = true;
        }
    }
}
