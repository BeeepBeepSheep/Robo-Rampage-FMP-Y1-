using UnityEngine;
using UnityEngine.AI;

public class EnemieController : MonoBehaviour
{
    public float lookRadius = 10f;
    Transform target;
    NavMeshAgent agent;
    public GameObject attackField;
    public Animator animController;
    //----------
    public Transform head;
    public bool canReachTarget;
    public bool canSeeTarget;
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
            // Chasing state
            animController.SetInteger("State", 3);

            NavMeshPath path = new NavMeshPath();
            agent.CalculatePath(target.position, path);

            if (path.status == NavMeshPathStatus.PathPartial)
            {
                //Unreachable state
                canReachTarget = false;
                TargetIsUnreachable_State();
            }
            if (path.status != NavMeshPathStatus.PathPartial)
            {
                agent.SetDestination(target.position);
                if (distance <= agent.stoppingDistance)
                {
                    // Attacking state
                    FaceTarget();
                    Punching_State();
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
    void Punching_State()
    {
        //Debug.Log("attacking");
        animController.SetInteger("State", 2);
    }
    void Turret_State()
    {
        Debug.Log("turret");
        animController.SetInteger("State", 1);

        agent.SetDestination(transform.position);
    }
    void TargetIsUnreachable_State()
    {
        FaceTarget();
        RaycastHit hit;
        if (Physics.Linecast(head.position, target.position,out hit))
        {
            if(hit.transform.name == "Player")
            {
                canSeeTarget = true;
                Turret_State();
            }
            else
            {
                canSeeTarget = false;
                // Chasing state
                agent.SetDestination(target.position);
                Debug.Log("chasing");
                animController.SetInteger("State", 3);
                //Debug.Log(hit.transform.name);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, lookRadius);
    }
}
