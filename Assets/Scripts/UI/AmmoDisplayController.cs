using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplayController : MonoBehaviour
{
    public GameObject TertararyAmmoDisplay;
    public GameObject MainAmmoDisplay;

    public GameObject DaulWieldHolder;
    void Update()
    {
        if (DaulWieldHolder.activeInHierarchy == true)
        {
            MainAmmoDisplay.SetActive(false);
            TertararyAmmoDisplay.SetActive(true);
        }
        if (DaulWieldHolder.activeInHierarchy == false)
        {
            MainAmmoDisplay.SetActive(true);
            TertararyAmmoDisplay.SetActive(false);
        }
    }
}
