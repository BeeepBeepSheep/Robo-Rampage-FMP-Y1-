using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{

    public float damage = 34f;
    public float range = 10f;
    public float fireRate = 30f;
    private float nextTimeToFire = 0f;

    public Camera cam;

    public Animator HitRegAnim;
    public Animator swordAnim;
    AudioSource stab;
    //void Start()
    //{
    //    gunShot = GetComponent<AudioSource>();
    //}
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Health.isBlocking = true;
            swordAnim.SetBool("Blocking", true);
            swordAnim.SetBool("Stabbing", false);

            if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1f / fireRate;
                swordAnim.SetBool("Blocking", false);
                swordAnim.SetBool("Stabbing", true);
                //Stab();
            }
        }
        if (Input.GetButtonUp("Fire2"))
        {
            swordAnim.SetBool("Blocking", false);
            Health.isBlocking = false;
        }
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            swordAnim.SetBool("Stabbing", true);
            //Stab();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            swordAnim.SetBool("Stabbing", false);
        }
    }
    void Stab()
    {
        //gunShot.Play();

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Health enemy = hit.transform.GetComponent<Health>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                HitRegAnim.SetTrigger("Hit");
            }
        }
        swordAnim.SetBool("Stabbing", false);
    }
}
