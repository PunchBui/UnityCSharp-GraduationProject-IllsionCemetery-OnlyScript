using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class TimedSpawn : MonoBehaviour
{
    public Transform[] spawnPointsT;
    public GameObject[] hazard;
    public float SpawnWait;
    public float starWait;
    public float waveWait;

    public static int SpawnWave = 5;
    public static int countkillzombie ;
    public static bool check = true;
    public static bool PassScene = false;
    int GetRandom(int count)
    {
        int random;
        while (true)
        {
            random = Random.Range(1, count);
            if (Vector3.Distance(spawnPointsT[random].position, this.transform.position) < 100)
            {
                break;
            }
        }
        return random;
    }
    int GetRandomZombie(int n)
    {
        int random;
            random = Random.Range(0, n);
        return random;
    }
    IEnumerator SpawnWaves() 
    {
        check = false;
        for (int i = 0; i < SpawnWave ; i++)
            {
                
                int randomInt = GetRandom(spawnPointsT.Length);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard[GetRandomZombie(hazard.Length)], spawnPointsT[randomInt].transform.position, spawnPointsT[randomInt].transform.rotation);
                 yield return new WaitForSeconds(SpawnWait);
            if(i == SpawnWave- 1)
            {
                Destroy(gameObject);
            }
                ///------------------------------------------------------------------------------------ 
             }
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && check)
        {
          
            SpawnWave = Random.Range(SpawnWave, SpawnWave + (TimeSpawnMainAc.countWave * 2));
            StartCoroutine(SpawnWaves());
            countkillzombie = 0;
        }
    }
}


