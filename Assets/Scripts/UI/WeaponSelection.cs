using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public GameObject AR;
    public GameObject Minigun;
    public GameObject Sniper;
    public GameObject Lmg;
    public GameObject Rifle;
    public GameObject Shotgun1;

    public GameObject Pistol;
    public GameObject Shotgun2;
    public GameObject Knife;
    public GameObject Uzi;


    public void AR_Selection()
    {
        AR.SetActive(true);
        Minigun.SetActive(false);
        Sniper.SetActive(false);
        Lmg.SetActive(false);
        Rifle.SetActive(false);
        Shotgun1.SetActive(false);

    }
    public void Minigun_Selection()
    {
        AR.SetActive(false);
        Minigun.SetActive(true);
        Sniper.SetActive(false);
        Lmg.SetActive(false);
        Rifle.SetActive(false);
        Shotgun1.SetActive(false);

    }
    public void Sniper_Selection()
    {
        AR.SetActive(false);
        Minigun.SetActive(false);
        Sniper.SetActive(true);
        Lmg.SetActive(false);
        Rifle.SetActive(false);
        Shotgun1.SetActive(false);

    }
    public void LMG_Selection()
    {
        AR.SetActive(false);
        Minigun.SetActive(false);
        Sniper.SetActive(false);
        Lmg.SetActive(true);
        Rifle.SetActive(false);
        Shotgun1.SetActive(false);

    }
    public void Rifle_Selection()
    {
        AR.SetActive(false);
        Minigun.SetActive(false);
        Sniper.SetActive(false);
        Lmg.SetActive(false);
        Rifle.SetActive(true);
        Shotgun1.SetActive(false);

    }
    public void Shotgun1_Selection()
    {
        AR.SetActive(false);
        Minigun.SetActive(false);
        Sniper.SetActive(false);
        Lmg.SetActive(false);
        Rifle.SetActive(false);
        Shotgun1.SetActive(true);

    }


    public void Knife_Selection()
    {
        Pistol.SetActive(false);
        Shotgun2.SetActive(false);
        Knife.SetActive(true);
        Uzi.SetActive(false);

    }
    public void Pistol_Selection()
    {
        Pistol.SetActive(true);
        Shotgun2.SetActive(false);
        Knife.SetActive(false);
        Uzi.SetActive(false);

    }
    public void Shotgun2_Selection()
    {
        Pistol.SetActive(false);
        Shotgun2.SetActive(true);
        Knife.SetActive(false);
        Uzi.SetActive(false);

    }
    public void Uzi_Selection()
    {
        Pistol.SetActive(false);
        Shotgun2.SetActive(false);
        Knife.SetActive(false);
        Uzi.SetActive(true);

    }
}
