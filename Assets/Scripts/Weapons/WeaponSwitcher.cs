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
        Primary.SetActive(true);
        Secondary.SetActive(false);
        Debug.Log(PrimaryActive);
        PrimaryActive = true;
    }
    void SwitchToSecondary()
    {
        Primary.SetActive(false);
        Secondary.SetActive(true);
        Debug.Log(PrimaryActive);
        PrimaryActive = false;
    }
}
