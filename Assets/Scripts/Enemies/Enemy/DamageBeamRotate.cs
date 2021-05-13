using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBeamRotate : MonoBehaviour
{
    public float speed = 200f;
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
    void OnTriggerEnter(Collider collision)
    {
        Health player = collision.transform.GetComponent<Health>();
        if (player != null)
        {
            player.currantHealth = player.maxHealth;
            Destroy(gameObject);
        }
    }
}
