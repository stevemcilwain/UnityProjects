
using UnityEngine;

public class EnemyDetectActionNode : ActionNode
{
    [SerializeField]
    private LayerMask targetLayers;

    [SerializeField]
    private float range = 5f;

    [SerializeField]
    private Transform origin;

    public override NodeStatus Tick(BehaviorState state)
    {
        var myState = (EnemyBehaviorState)state;

        Log("Searching for player...");

        myState.Target = FindTarget();

        if (myState.Target != null)
        {
            Log("Target set: " + myState.Target.name);
            return NodeStatus.SUCCESS;
        }
        else
        {

            LogWarning("No player target found");
            return NodeStatus.FAILURE;
        }
    }

    private Transform FindTarget()
    {
        Transform result = null;

        Collider[] hits = Physics.OverlapSphere(origin.position, range, targetLayers);

        if (hits.Length > 0) result = hits[0].transform;

        return result;
    }
}