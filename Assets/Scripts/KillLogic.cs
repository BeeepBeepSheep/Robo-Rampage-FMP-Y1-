using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KillLogic : MonoBehaviour
{
    public TextMeshProUGUI KillCounter;
    public static int kills;

    void Start()
    {
        kills = 0;
    }

    void Update()
    {


        KillCounter.text = kills.ToString();
    }
}
