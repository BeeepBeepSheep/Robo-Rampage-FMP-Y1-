using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{
    public GameObject ar;
    public GameObject miniGun;
    public GameObject sniper;
    public GameObject lmg;
    public GameObject rifle;
    public GameObject pumpShotty;

    public GameObject pistol;
    public GameObject sawedShotty;
    public GameObject knife;
    public GameObject uzi;
    public GameObject revolvers;

    public GameObject heal;
    public GameObject grenade;
    public GameObject superHeal;

    public void AR_Selection()
    {
        ar.SetActive(true);
        miniGun.SetActive(false);
        sniper.SetActive(false);
        lmg.SetActive(false);
        rifle.SetActive(false);
        pumpShotty.SetActive(false);

    }
    public void Minigun_Selection()
    {
        ar.SetActive(false);
        miniGun.SetActive(true);
        sniper.SetActive(false);
        lmg.SetActive(false);
        rifle.SetActive(false);
        pumpShotty.SetActive(false);

    }
    public void Sniper_Selection()
    {
        ar.SetActive(false);
        miniGun.SetActive(false);
        sniper.SetActive(true);
        lmg.SetActive(false);
        rifle.SetActive(false);
        pumpShotty.SetActive(false);

    }
    public void LMG_Selection()
    {
        ar.SetActive(false);
        miniGun.SetActive(false);
        sniper.SetActive(false);
        lmg.SetActive(true);
        rifle.SetActive(false);
        pumpShotty.SetActive(false);

    }
    public void Rifle_Selection()
    {
        ar.SetActive(false);
        miniGun.SetActive(false);
        sniper.SetActive(false);
        lmg.SetActive(false);
        rifle.SetActive(true);
        pumpShotty.SetActive(false);

    }
    public void Shotgun1_Selection()
    {
        ar.SetActive(false);
        miniGun.SetActive(false);
        sniper.SetActive(false);
        lmg.SetActive(false);
        rifle.SetActive(false);
        pumpShotty.SetActive(true);

    }
    //-----------------------------
    public void Knife_Selection()
    {
        pistol.SetActive(false);
        sawedShotty.SetActive(false);
        knife.SetActive(true);
        uzi.SetActive(false);
        revolvers.SetActive(false);

    }
    public void Pistol_Selection()
    {
        pistol.SetActive(true);
        sawedShotty.SetActive(false);
        knife.SetActive(false);
        uzi.SetActive(false);
        revolvers.SetActive(false);

    }
    public void Shotgun2_Selection()
    {
        pistol.SetActive(false);
        sawedShotty.SetActive(true);
        knife.SetActive(false);
        uzi.SetActive(false);
        revolvers.SetActive(false);

    }
    public void Uzi_Selection()
    {
        pistol.SetActive(false);
        sawedShotty.SetActive(false);
        knife.SetActive(false);
        uzi.SetActive(true);
        revolvers.SetActive(false);

    }
    public void Revolvers_Selection()
    {
        pistol.SetActive(false);
        sawedShotty.SetActive(false);
        knife.SetActive(false);
        uzi.SetActive(false);
        revolvers.SetActive(true);
    }
    //-----------------------------
    public void Heal_Selection()
    {
        heal.SetActive(true);
        grenade.SetActive(false);
        superHeal.SetActive(false);
    }
    public void Grenade_Selection()
    {
        heal.SetActive(false);
        grenade.SetActive(true);
        superHeal.SetActive(false);
    }
    public void SuperHeal_Selection()
    {
        heal.SetActive(false);
        grenade.SetActive(false);
        superHeal.SetActive(true);
    }
}
