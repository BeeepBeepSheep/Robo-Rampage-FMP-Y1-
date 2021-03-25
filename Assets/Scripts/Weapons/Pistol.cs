using UnityEngine;

public class Pistol : MonoBehaviour
{
    public float damage = 34f;
    public float range = 100f;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float impactForce = 30f;

    public Camera cam;

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        muzzleFlash.Play();
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            GameObject impactGameObject = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGameObject, 2f);
        }
    }
}
