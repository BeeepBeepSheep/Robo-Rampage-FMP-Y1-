using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplayController : MonoBehaviour
{
    public GameObject TertararyAmmoDisplay;
    public GameObject MainAmmoDisplay;

    public GameObject revolvers;
    void Update()
    {
        if (revolvers.activeInHierarchy == true)
        {
            MainAmmoDisplay.SetActive(false);
            TertararyAmmoDisplay.SetActive(true);
        }
        if (revolvers.activeInHierarchy == false)
        {
            MainAmmoDisplay.SetActive(true);
            TertararyAmmoDisplay.SetActive(false);
        }
    }
}
