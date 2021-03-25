using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public GameObject ADS;
    public GameObject HIP;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ADS.SetActive(true);
            HIP.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ADS.SetActive(false);
            HIP.SetActive(true);
        }
    }

}
