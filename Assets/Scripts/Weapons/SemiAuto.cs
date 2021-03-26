using UnityEngine;
using System.Collections;

public class SemiAuto : MonoBehaviour
{
    public float damage = 34f;
    public float range = 100f;
    public float fireRate = 30f;

    public GameObject impactEffect;
    public float impactForce = 30f;
    public Camera cam;

    public int maxAmmo = 10;
    private int currantAmmo;
    public float reloadTime = 1f;
    private bool isReloading;

    private float nextTimeToFire = 0f;

    public Animator shootAnim;
    public Animator reloadAnim;
    public GameObject reloadSymbol;

    void Start()
    {
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
        if (isReloading)
            return;
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
            return;
        }
        if (currantAmmo <= 0)
        {
            StartCoroutine(Reload());
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

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
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
