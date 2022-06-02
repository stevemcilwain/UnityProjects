using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveActionNode : ActionNode
{

    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private float range = 5f;


    private void Awake()
    {

        if (agent == null)
        {
            LogWarning("NavMeshAgent is not assigned in the inspector, searching parent...");

            agent = GetComponentInParent<NavMeshAgent>(true);

            if (agent == null)
            {
                LogError("No NavMeshAgent assigned or available.");
            }
        }

    }

    public override NodeStatus Tick(BehaviorState state)
    {

        var s = (EnemyBehaviorState)state;

        if (!s.Moving && !s.Chasing)
        {
            s.MovementDestination = RandomNavmeshLocation(range);
            Log("Setting destination to: " + s.MovementDestination);
            agent.SetDestination(s.MovementDestination);
            s.Moving = true;
        }
        else
        {
            Log("Moving to: " + s.MovementDestination);

            if (agent.pathStatus == NavMeshPathStatus.PathComplete && agent.remainingDistance < 2f)
            {
                Log("Reached: " + s.MovementDestination);
                s.Moving = false;
                s.MovementDestination = Vector3.zero;
                return NodeStatus.SUCCESS;
            }
        }

        return NodeStatus.RUNNING;

    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if (NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        Log("Chose random destination: " + finalPosition);
        return finalPosition;
    }

}
