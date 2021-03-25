using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject Primary;
    public GameObject Secondary;

    public bool PrimaryActive;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchToPrimary();
            Debug.Log(PrimaryActive);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchToSecondary();
            Debug.Log(PrimaryActive);
        }
        if (PrimaryActive)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                SwitchToSecondary();
            }
        }
        if (!PrimaryActive)
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                SwitchToPrimary();
            }
        }
    }

    void SwitchToPrimary()
    {
        PrimaryActive = true;
        Primary.SetActive(true);
        Secondary.SetActive(false);
    }
    void SwitchToSecondary()
    {
        PrimaryActive = false;
        Primary.SetActive(false);
        Secondary.SetActive(true);
    }
}
