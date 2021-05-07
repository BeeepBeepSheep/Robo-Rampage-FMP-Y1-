using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemieController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    public GameObject attackField;
    public Animator animController;
    void Start()
    {
        target = PlayerManeger.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            //Debug.Log("chasing");
            animController.SetInteger("State", 3);

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(target.position, path);
            if (path.status == NavMeshPathStatus.PathPartial)
            {
                TargetIsUnreachable();
            }
            if (path.status != NavMeshPathStatus.PathPartial)
            {
                //Debug.Log("Can reach");

                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    FaceTarget();
                    Attack();
                }
            }
        }
        else
        {
            animController.SetInteger("State", 1);
            //Debug.Log("idle");
        }
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    void Attack()
    {
        //Debug.Log("attacking");
        animController.SetInteger("State", 2);
    }
    void TargetIsUnreachable()
    {
        //Debug.Log("Cannot reach");
        animController.SetInteger("State", 1);

        agent.SetDestination(transform.position);
        FaceTarget();
        return;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }
}
