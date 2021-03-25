using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    public GameObject Primary;
    public GameObject Secondary;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Primary.SetActive(true);
            Secondary.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Primary.SetActive(false);
            Secondary.SetActive(true);
        }
    }
}
