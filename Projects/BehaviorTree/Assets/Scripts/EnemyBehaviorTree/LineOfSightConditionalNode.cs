using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSightConditionalNode : ActionNode
{

    public float Radius;
    public float Angle;
    public Transform Origin;
    public LayerMask TargetMask;
    public LayerMask ObstructionMask;
    public int MaxTargets = 1;


    private void Awake()
    {
        Debug.Assert(Origin != null, "Parent body assignment missing from node.", gameObject);
    }

    private void Update()
    {
        var origin = new Vector3(Origin.transform.position.x, Origin.transform.position.y + 1f, Origin.transform.position.z);

        Debug.DrawRay(origin, Origin.transform.forward * Radius, Color.yellow);
    }

    public override NodeStatus Tick(BehaviorState state)
    {
        if (LookAround())
        {
            return NodeStatus.SUCCESS;
        }
        else
        {
            return NodeStatus.FAILURE;
        }
    }

    private bool LookAround()
    {

        bool result = false;

        HashSet<string> targets = new();

        Collider[] hits = Physics.OverlapSphere(Origin.transform.position, Radius, TargetMask);

        if (hits.Length > 0)
        {
            foreach (var hit in hits)
            {
                var target = hit.transform;

                Vector3 direction = (target.position - Origin.transform.position).normalized;
                float angle = Vector3.Angle(direction, Origin.transform.forward);

                float distance = Vector3.Distance(Origin.transform.position, target.position);

                if (angle < Angle / 2)
                {
                    if (distance < Radius)
                    {
                        Debug.DrawLine(Origin.transform.position, target.position, Color.green, 1f);
                        targets.Add(hit.gameObject.name);

                        Log("Discovered " + hit.gameObject.name);

                        if (targets.Count >= MaxTargets)
                        {
                            Log("Found " + targets.Count + " enemies");
                            return true;
                        }

                    }
                    else
                    {
                        Debug.DrawLine(Origin.transform.position, target.position, Color.red, 1f);
                    }
                }

            }

        }
        return result;
    }

}
