using UnityEngine;
using UnityEngine.AI;

public class GhostMovement : MonoBehaviour
{
    public Transform target;
    [SerializeField] private float moveSpeed = 2.5f;

    private NavMeshAgent agent;

    public bool fleeing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    void Pursue()
    {
        //Direction of target
        Vector3 targetDir = target.transform.position - transform.position;

        //If the agent is ahead of the target, go to seek
        float relativeHeading = Vector3.Angle(transform.forward, transform.TransformVector(target.transform.forward));
        //Getting angle, if the angle is small we'll seek instead
        float toTarget = Vector3.Angle(transform.forward, transform.TransformVector(targetDir));

        float targetSpeed = target.GetComponent<PlayerMovement>().GetMovementSpeed();
        if ((toTarget > 90 && relativeHeading < 20) || targetSpeed < 0.01f)
        {
            Seek(target.transform.position);
            return;
        }

        float lookAhead = targetDir.magnitude / (agent.speed + targetSpeed);
        Seek(target.transform.position + target.transform.forward * lookAhead);
    }

    void Seek(Vector3 location)
    {
        agent.SetDestination(location);
    }

    void Flee(Vector3 location)
    {
        Vector3 fleeVector = location - transform.position;
        agent.SetDestination(transform.position - fleeVector);
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            if (fleeing == false)
            {
                Pursue();
            }
            else if (fleeing)
            {
                Flee(target.transform.position);
            }
        }
    }
}