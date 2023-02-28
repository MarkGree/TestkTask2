using UnityEngine;
using UnityEngine.AI;

public class NavMeshMovement : Movement
{
    [SerializeField] private NavMeshAgent agent;
    
    private bool isMoving;
    public override bool IsMoving => isMoving;

    private const float movingVelocityThreshold = 0.2f;

    public override void FollowAt(Vector3 point)
    {
        agent.SetDestination(point);
        isMoving = true;
    }

    private void Update()
    {
        if (isMoving) 
        {
            if (!agent.hasPath || agent.velocity.sqrMagnitude < movingVelocityThreshold)
            {
                isMoving = false;
            }
        }
        else
        {
            if (agent.hasPath && agent.velocity.sqrMagnitude > movingVelocityThreshold)
            {
                isMoving = true;
            }
        }
    }

    public override void Stop()
    {
        agent.SetDestination(transform.position + transform.forward * 0.1f);
        isMoving = false;
    }
}
