using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public GameObject ADS;
    public GameObject HIP;
    bool canAim;

    public GameObject muzleflashHip;
    public GameObject muzleflasAim;


    private void Start()
    {
        canAim = true;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            canAim = true;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            canAim = false;
            StopAim();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && canAim)
        {
            ADS.SetActive(true);
            muzleflasAim.SetActive(true);

            HIP.SetActive(false);
            muzleflashHip.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            StopAim();
        }
    }
    void StopAim()
    {
        HIP.SetActive(true);
        muzleflashHip.SetActive(true);

        ADS.SetActive(false);
        muzleflasAim.SetActive(false);
    }
}
