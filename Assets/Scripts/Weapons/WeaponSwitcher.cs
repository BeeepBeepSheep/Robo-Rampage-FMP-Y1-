using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject Primary;
    public GameObject Secondary;
    public GameObject Tertarary;

    public bool PrimaryActive;

    void Start()
    {
        SwitchToSecondary();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToPrimary();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchToSecondary();
        }
        if (PrimaryActive)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                SwitchToSecondary();
            }
            SwitchToTertarary();

        }
        if (!PrimaryActive)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                SwitchToPrimary();
            }
            SwitchToTertarary();
        }
    }

    void SwitchToPrimary()
    {
        Primary.SetActive(true);
        Secondary.SetActive(false);
        Tertarary.SetActive(false);
        //Debug.Log(PrimaryActive);
        PrimaryActive = true;
    }
    void SwitchToSecondary()
    {
        Primary.SetActive(false);
        Secondary.SetActive(true);
        Tertarary.SetActive(false);
        //Debug.Log(PrimaryActive);
        PrimaryActive = false;
    }
    void SwitchToTertarary()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Primary.SetActive(false);
            Secondary.SetActive(false);
            Tertarary.SetActive(true);
            //Debug.Log(PrimaryActive);
            PrimaryActive = false;
        }
    }
}
