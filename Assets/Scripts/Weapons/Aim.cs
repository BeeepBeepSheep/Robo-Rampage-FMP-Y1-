using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public GameObject ADS;
    public GameObject HIP;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            StopAim();
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            AimDownSights();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopAim();
        }
    }
    void StopAim()
    {
        HIP.SetActive(true);

        ADS.SetActive(false);
    }
    void AimDownSights()
    {
        {
            ADS.SetActive(true);

            HIP.SetActive(false);
        }
    }
}
