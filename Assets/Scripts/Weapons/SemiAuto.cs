using UnityEngine;

public class SemiAuto : MonoBehaviour
{
    public float damage = 34f;
    public float range = 100f;
    public float fireRate = 30f;

    public GameObject impactEffect;
    public float impactForce = 30f;
    public Camera cam;

    private float nextTimeToFire = 0f;

    void Update()
    {
        //change to just get button for single fire (getButtonDown for full auto
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    void Shoot()
    {
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
    }
}
