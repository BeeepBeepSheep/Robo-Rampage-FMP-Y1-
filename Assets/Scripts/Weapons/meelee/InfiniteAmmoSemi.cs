using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteAmmoSemi : MonoBehaviour
{
    public float damage = 34f;
    public float range = 10f;
    public float fireRate = 30f;

    public GameObject impactEffect;
    public float impactForce = 30f;
    public Camera cam;
    public Animator HitReg;

    public Animator shootAnim;
    AudioSource gunShot;
    private float nextTimeToFire = 0f;


    void Start()
    {
        gunShot = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        shootAnim.SetBool("Reloading", false);
    }
        void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            shootAnim.SetBool("Stabbing", false);
        }
    }

    void Shoot()
    {
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
            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 2f);
        }
        shootAnim.SetBool("Stabbing", true);
    }
}
