using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RevolverLeft : MonoBehaviour
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
    private int currantAmmo;
    public float reloadTime = 1f;
    private bool isReloading;
    public Text ammoDisplay;
    public GameObject reloadPrompt;

    AudioSource gunShot;
    private float nextTimeToFire = 0f;
    private bool isSprinting;

    public Animator shootAnim;
    public Animator reloadAnim;
    public GameObject reloadSymbol;

    public Animator muzzleFlashAnim;


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
            reloadPrompt.SetActive(true);
            return;
        }
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            shootAnim.SetBool("Shooting", false);
        }
    }
    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading");
        shootAnim.SetBool("Shooting", false);


        reloadAnim.SetBool("Reloading", true);
        reloadSymbol.SetActive(true);

        reloadPrompt.SetActive(true);
        yield return new WaitForSeconds(reloadTime - .25f);

        reloadAnim.SetBool("Reloading", false);
        yield return new WaitForSeconds(.25f);

        reloadSymbol.SetActive(false);
        currantAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        currantAmmo--;
        muzzleFlashAnim.SetTrigger("Flash");


        gunShot.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

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
