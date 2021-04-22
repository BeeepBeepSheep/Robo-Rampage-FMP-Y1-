using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Wave
{
    public string waveName;
    public int numberOfEnemes;
    public GameObject[] typeOfEnemies;
    public float spawnInterval;
}
public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPonts;

    private Wave currantWave;
    public int currantWaveNumber;
    private float nextSpawnTime;

    private bool canSpawn = true;

    private void Update()
    {
        currantWave = waves[currantWaveNumber];
        SpawnWave();
        GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(totalEnemies.Length == 0 && !canSpawn && currantWaveNumber+1 != waves.Length)
        {
            currantWaveNumber ++;
            canSpawn = true;
        }
    }
    void SpawnWave()
    {
        if(canSpawn && nextSpawnTime < Time.time)
        {
            GameObject randomEnemy = currantWave.typeOfEnemies[Random.Range(0, currantWave.typeOfEnemies.Length)];
            Transform randomPoint = spawnPonts[Random.Range(0, spawnPonts.Length)];
            Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
            currantWave.numberOfEnemes--;
            nextSpawnTime = Time.time + currantWave.spawnInterval;

            if(currantWave.numberOfEnemes == 0)
            {
                canSpawn = false;
            }
        }
    }
}
