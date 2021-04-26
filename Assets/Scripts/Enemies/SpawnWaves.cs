using System.Collections;
using UnityEngine;

public class SpawnWaves : MonoBehaviour
{
    public GameObject enemyPrefab;
    private int enemyCount;
    private int waveNumber = 1;

    public float timeBetweenEnemySpawn;
    public float timeBetweenWaves;

    public Transform[] spawnPoints;

    bool spawningWave;

    public Animator anim;

    void Start()
    {
        StartCoroutine(SpawnEnemyWave(waveNumber));
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && !spawningWave)
        {
            waveNumber++;
            KillLogic.wave++;
            StartCoroutine(SpawnEnemyWave(waveNumber));
        }
    }

    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        spawningWave = true;
        anim.SetBool("NewWave", true);
        yield return new WaitForSeconds(timeBetweenWaves); //We wait here to pause between wave spawning
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(timeBetweenEnemySpawn); //We wait here to give a bit of time between each enemy spawn
        }
        spawningWave = false;
        anim.SetBool("NewWave", false);
    }
}
