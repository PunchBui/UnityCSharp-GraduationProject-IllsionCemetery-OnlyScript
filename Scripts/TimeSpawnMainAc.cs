using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSpawnMainAc : MonoBehaviour
{
    public  GameObject WaveStartAnime;
    public  Text TextCountWave;
    public  Text CountZombie;
    public  GameObject ImageCountzombie;
    bool SpawnMap3 = false;
    public static bool thischeck = true;
    public static int countWave = 0;

    void Update()
    {
        if ((TimedSpawn.countkillzombie == TimedSpawn.SpawnWave) || TimedSpawn.PassScene)
        {
            if (SpawnMap3)
            {
                SpawnwaveMap3.CountWavemap3++;
                SpawnMap3 = false;
            }
            TimedSpawn.PassScene = false;
                TimedSpawn.check = true;
            thischeck = true;
            TextCountWave.text = "END";
            ImageCountzombie.SetActive(false);
        }
        CountZombie.text = TimedSpawn.countkillzombie.ToString() + "/" + TimedSpawn.SpawnWave.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "spawn" && thischeck)
        {
            thischeck = false;
            countWave++;
            WaveStartAnime.SetActive(true);
            ImageCountzombie.SetActive(true);
            StartCoroutine(deleteBanner());
            CountZombie.text = "0" +"/" + TimedSpawn.SpawnWave.ToString();
            TextCountWave.text = countWave.ToString();
        }
        if (other.tag == "spawnmap3" && thischeck)
        {
            SpawnMap3 = true;
            thischeck = false;
            countWave++;
            WaveStartAnime.SetActive(true);
            ImageCountzombie.SetActive(true);
            StartCoroutine(deleteBanner());
            CountZombie.text = "0" + "/" + TimedSpawn.SpawnWave.ToString();
            TextCountWave.text = countWave.ToString();
        }
    }
    IEnumerator deleteBanner()
    {
        yield return new WaitForSeconds(3);
        WaveStartAnime.SetActive(false);
    }
}
