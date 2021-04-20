using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage = 1f;
    public bool attacking;
    public Animator animator;
    public GameObject player1;
    void Update()
    {
        //if attack animation plays, deal damage
        //animator.SetInteger("State", 2);
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_Arm_1"))
        {
            if(attacking)
            {
                return;
            }

            Debug.Log("Attacking 1");
            Health player = player1.transform.GetComponent<Health>();
            player.TakeDamage(damage);
        }

    }
}
