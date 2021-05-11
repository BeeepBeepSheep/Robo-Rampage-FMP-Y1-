using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Autamatic : MonoBehaviour
{
    public float damage = 34f;
    public float range = 100f;
    public float fireRate = 30f;

    public GameObject impactEffect;
    public float impactForce = 30f;
    public Camera cam;
    public Animator HitReg;

    public int maxAmmo = 10;
    private int currantAmmo;
    public float reloadTime = 1f;
    private bool isReloading;
    public Text ammoDisplay;

    public Color Common;
    public Color Rare;
    public Color Legendary;

    AudioSource gunShot;
    private float nextTimeToFire = 0f;
    private bool isSprinting;

    public Animator shootAnim;
    public Animator reloadAnim;
    public GameObject reloadSymbol;

    public Animator muzzleFlashAnimAds;
    public Animator muzzleFlashAnimHip;

    void Start()
    {
        gunShot = GetComponent<AudioSource>();
        currantAmmo = maxAmmo;
    }
    void OnEnable()
    {
        isReloading = false;
        reloadAnim.SetBool("Reloading", false);
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
        ammoDisplay.text = currantAmmo.ToString();
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            if (isReloading)
            {
                StopCoroutine(Reload());
                shootAnim.SetBool("Reloading", false);
                reloadSymbol.SetActive(false);
            }
        }
        if (isSprinting)
        {
            StopCoroutine(Reload());
            isReloading = false;
            shootAnim.SetBool("Reloading", false);
            reloadSymbol.SetActive(false);
        }
        if (isReloading)
        {
            if (!PauseMenu2.GameISPaused)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    shootAnim.SetBool("Reloading", false);
                    reloadSymbol.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    shootAnim.SetBool("Reloading", false);
                    reloadSymbol.SetActive(false);
                }
            }
            if (PauseMenu2.GameISPaused)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    shootAnim.SetBool("Reloading", true);
                    reloadSymbol.SetActive(false);
                }
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    shootAnim.SetBool("Reloading", true);
                    reloadSymbol.SetActive(false);
                }
            }
            return;
        }
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            if (currantAmmo == maxAmmo)
            {
                return;
            }
            if (!isSprinting)
            {
                StartCoroutine(Reload());
            }
            return;
        }
        if (currantAmmo <= 0)
        {
            return;
        }
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            shootAnim.SetBool("Shooting", false);
            muzzleFlashAnimAds.SetBool("AutamaticShooting", false);
            muzzleFlashAnimHip.SetBool("AutamaticShooting", false);
        }
    }
    IEnumerator Reload()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            
        }
        if (!isSprinting)
        {
            isReloading = true;
            shootAnim.SetBool("Shooting", false);

            reloadAnim.SetBool("Reloading", true);
            reloadSymbol.SetActive(true);
            if(isSprinting)
            {
                reloadAnim.SetBool("Reloading", false);
                reloadSymbol.SetActive(false);
            }
            yield return new WaitForSeconds(reloadTime - .25f);
            if (!isSprinting)
            {
                reloadAnim.SetBool("Reloading", false);
            }
            yield return new WaitForSeconds(.25f);

            reloadSymbol.SetActive(false);
            if (!isSprinting)
            {
                currantAmmo = maxAmmo;
            }
            isReloading = false;
        }
    }

    void Shoot()
    {
        currantAmmo--;
        muzzleFlashAnimAds.SetBool("AutamaticShooting", true);
        muzzleFlashAnimHip.SetBool("AutamaticShooting", true);

        gunShot.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
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
            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 2f);
        }
        shootAnim.SetBool("Shooting", true);
    }
}
