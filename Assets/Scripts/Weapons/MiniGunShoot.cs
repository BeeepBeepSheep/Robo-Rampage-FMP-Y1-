using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniGunShoot : MonoBehaviour
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
    public Text ammoDisplay;

    private float nextTimeToFire = 0f;
    public bool isSprinting;

    AudioSource gunShot;

    public Animator shootAnim;
    public Animator reloadAnim;
    public GameObject reloadSymbol;

    void Start()
    {
        gunShot = GetComponent<AudioSource>();
        currantAmmo = maxAmmo;
    }
    void OnEnable()
    {
        reloadAnim.SetBool("Reloading", false);
        reloadSymbol.SetActive(false);
        //max ammo will equil the amount of kill every time u rebuy the weapon
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            shootAnim.SetBool("Shooting", false);
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
                GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGameObject, 2f);
            }
            shootAnim.SetBool("Shooting", true);
        }
    }
}
