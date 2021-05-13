using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGunShoot : MonoBehaviour
{
    public float damage = 34f;
    public float range = 100f;
    public float fireRate = 30f;

    public GameObject impactEffect;
    public GameObject impactEffectConcrete;
    public float impactForce = 30f;
    public Camera cam;
    public Animator HitReg;

    public int maxAmmo = 10;
    public int currantAmmo;
    public Text ammoDisplay;
    public Animator reloadAnim;
    public GameObject reloadSymbol;

    public Color Common;
    public Color Rare;
    public Color Legendary;

    private float nextTimeToFire = 0f;
    public bool isSprinting;

    AudioSource gunShot;

    public Animator shootAnim;

    public Animator muzzleFlashAnim;
    void Start()
    {
        gunShot = GetComponent<AudioSource>();
        ResetAmmo();
    }
    void OnEnable()
    {
        shootAnim.SetBool("Reloading", false);
        reloadSymbol.SetActive(false);

        if (gameObject.tag == "Common")
        {
            ammoDisplay.color = Common;
        }
        if (gameObject.tag == "Rare")
        {
            ammoDisplay.color = Rare;
        }
        if (gameObject.tag == "Legendary")
        {
            ammoDisplay.color = Legendary;
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            shootAnim.SetBool("Shooting", false);
            reloadAnim.SetBool("Reloading", false);
        }
        if (currantAmmo <= -1)
        {
            return;
        }
        if (Input.GetKey(KeyCode.Mouse1))
        {
            ammoDisplay.text = currantAmmo.ToString();

            if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                Shoot();
            }
            if (Input.GetButtonUp("Fire1"))
            {
                shootAnim.SetBool("Shooting", false);
                muzzleFlashAnim.SetBool("MinigunShooting", false);
            }
        }
    }
    void Shoot()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            return;
        }
        else
        {
            currantAmmo--;
            muzzleFlashAnim.SetBool("MinigunShooting",true);
            gunShot.Play();

            RaycastHit hit;
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
            {
                //Debug.Log(hit.transform.name);

                Health enemy = hit.transform.GetComponent<Health>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    HitReg.SetTrigger("Hit");
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }
                if (hit.transform.tag == "Enemy")
                {
                    GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGameObject, 1f);
                }
                else
                {
                    GameObject impactGameObject = Instantiate(impactEffectConcrete, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(impactGameObject, 1f);
                }
            }
            shootAnim.SetBool("Shooting", true);
        }
    }
    public void ResetAmmo()
    {
        currantAmmo = maxAmmo;
    }
}
