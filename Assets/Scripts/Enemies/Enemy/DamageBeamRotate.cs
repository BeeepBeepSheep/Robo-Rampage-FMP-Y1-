using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBeamRotate : MonoBehaviour
{
    public float speed = 200f;
    public float damage = 5f;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider collision)
    {
        Health player = collision.transform.GetComponent<Health>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}
