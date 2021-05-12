using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public GameObject player1;

    public float minDamage;
    public float maxDamage;
    void Start()
    {
        player1 = GameObject.FindGameObjectWithTag("PlayerCapsual");

        //damageIndicator = GameObject.FindGameObjectWithTag("DamageIndicator");
    }
    void Update()
    {
        damage = Random.Range(minDamage, maxDamage);
    }
    public void DoDamage()
    {
        Health player = player1.GetComponent<Health>();
        player.TakeDamage(damage);
    }
}
