using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KillLogic : MonoBehaviour
{
    public TextMeshProUGUI KillCounter;
    public TextMeshProUGUI WaveCounter;
    public static int kills;
    public static int wave;

    void Start()
    {
        kills = 0;
        wave = 1;
    }

    void Update()
    {
        KillCounter.text = kills.ToString();
        WaveCounter.text = wave.ToString();
    }
}
