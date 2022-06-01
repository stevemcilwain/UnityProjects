using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseClosestActionNode : ActionNode
{

    [SerializeField]
    private NavMeshAgent agent;

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

        if (s == null)
        {
            agent.isStopped = true;
            return NodeStatus.FAILURE;
        }
        else
        {
            agent.SetDestination(s.Target.transform.position);
        }

        return NodeStatus.RUNNING;
    }


}
