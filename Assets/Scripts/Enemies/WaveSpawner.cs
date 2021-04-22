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
    [SerializeField] Wave[] waves;
}
