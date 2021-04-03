using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public GameObject AR;
    public GameObject Minigun;
    public GameObject Sniper;

    public GameObject Pistol;
    public GameObject ShotGun;
    public GameObject Knife;

    public void AR_Selection()
    {
        AR.SetActive(true);
        Minigun.SetActive(false);
        Sniper.SetActive(false);
    }
    public void Minigun_Selection()
    {
        AR.SetActive(false);
        Minigun.SetActive(true);
        Sniper.SetActive(false);
    }
    public void Sniper_Selection()
    {
        AR.SetActive(false);
        Minigun.SetActive(false);
        Sniper.SetActive(true);
    }
    public void Knife_Selection()
    {
        Pistol.SetActive(false);
        ShotGun.SetActive(false);
        Knife.SetActive(true);
    }
    public void Pistol_Selection()
    {
        Pistol.SetActive(true);
        ShotGun.SetActive(false);
        Knife.SetActive(false);
    }
    public void Shotgun_Selection()
    {
        Pistol.SetActive(false);
        ShotGun.SetActive(true);
        Knife.SetActive(false);
    }
}
