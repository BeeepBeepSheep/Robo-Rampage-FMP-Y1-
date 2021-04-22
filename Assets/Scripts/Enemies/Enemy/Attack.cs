using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float damage;
    public bool attacking;
    public Animator animator;
    public GameObject player1;
    //public GameObject damageIndicator;

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
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack_Arm_1"))
        {
            if (attacking)
            {
                return;
            }
            StartCoroutine(DoDamage());
        }
    }
    IEnumerator DoDamage()
    {
        attacking = true;
        yield return new WaitForSeconds(.50f);
        //damageIndicator.SetActive(true);

        yield return new WaitForSeconds(.35f);
        Health player = player1.GetComponent<Health>();
        player.TakeDamage(damage);
        Debug.Log("takes damage");

        yield return new WaitForSeconds(.15f);
        //damageIndicator.SetActive(false);
        attacking = false;
    }
}
