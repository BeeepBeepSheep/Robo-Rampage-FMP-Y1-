using System.Collections;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class SpawnWaves : MonoBehaviour
{
    public Transform[] enemyPrefab;
    private int enemyCount;
    private int maxEnemiesForWave = 1;

    public float timeBetweenEnemySpawn;
    public float timeBetweenWaves;

    public Transform[] spawnPoints;

    bool spawningWave;

    public Animator anim;

    public Image healer1_Icon;
    public Image healer2_Icon;

    public GameObject healer1;
    public GameObject healer2;
    public GameObject miniGun;

    void Start()
    {
        StartCoroutine(SpawnEnemyWave(maxEnemiesForWave));
    }

    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount == 0 && !spawningWave)
        {
            maxEnemiesForWave++;
            KillLogic.wave++;
            StartCoroutine(SpawnEnemyWave(maxEnemiesForWave));
        }
    }

    IEnumerator SpawnEnemyWave(int enemiesToSpawn)
    {
        spawningWave = true;
        anim.SetBool("NewWave", true);
        ResetConsumables();

        yield return new WaitForSeconds(timeBetweenWaves); //We wait here to pause between wave spawning
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(timeBetweenEnemySpawn); //We wait here to give a bit of time between each enemy spawn
        }
        spawningWave = false;
        anim.SetBool("NewWave", false);
    }
    void ResetConsumables()
    {
        Heal reset = healer1.GetComponent<Heal>();
        reset.ResetHealAmmount();

        Heal reset2 = healer2.GetComponent<Heal>();
        reset2.ResetHealAmmount();

        MiniGunShoot reset3 = miniGun.GetComponent<MiniGunShoot>();
        reset3.ResetAmmo();

        healer1_Icon.fillAmount = 1f;
        healer2_Icon.fillAmount = 1f;
    }
}