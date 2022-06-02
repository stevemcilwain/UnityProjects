
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaseActionNode : ActionNode
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
        var target = s.Target;

        if (target == null)
        {
            LogWarning("No target set for enemy to chase.");
            s.Chasing = false;
            agent.isStopped = true;
            return NodeStatus.FAILURE;
        }
        else
        {
            Log("Setting target to: " + target.name);
            s.Chasing = true;
            agent.SetDestination(target.transform.position);
            return NodeStatus.SUCCESS;
        }
    }


}
