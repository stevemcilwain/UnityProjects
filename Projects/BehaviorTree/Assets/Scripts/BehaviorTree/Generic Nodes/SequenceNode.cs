
/// <summary>
/// A sequence node executes all child nodes (from top to bottom).
/// If one node fails, execution stops and returns failure.
/// </summary>
public class SequenceNode : CompositeNode
{

    public override NodeStatus Tick(BehaviorState state)
    {
        NodeStatus status = children[Current].Tick(state);

        Log(status.ToString());

        // return running, the parent will continue calling Tick()
        if (status == NodeStatus.RUNNING) return NodeStatus.RUNNING;

        // return failure and the parent will stop calling Tick()
        if (status == NodeStatus.FAILURE) return status;

        // not RUNNING or FAILED, so increment Current Node
        Current++;

        // check for any more nodes and complete if done
        if (Current >= children.Length)
        {
            Current = 0;
            return NodeStatus.SUCCESS;
        }

        return NodeStatus.RUNNING;
    }
}
