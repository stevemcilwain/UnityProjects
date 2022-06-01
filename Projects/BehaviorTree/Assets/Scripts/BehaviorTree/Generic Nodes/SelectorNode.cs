/// <summary>
/// A selector node executes one of multiple children
/// </summary>
public class SelectorNode : CompositeNode
{

    public override NodeStatus Tick(BehaviorState state)
    {
        NodeStatus status = children[Current].Tick(state);

        Log(status.ToString());

        // return running, the parent will continue calling Tick()
        if (status == NodeStatus.RUNNING) return NodeStatus.RUNNING;

        // return success and the parent will stop calling Tick()
        if (status == NodeStatus.SUCCESS)
        {
            Current = 0;
            return NodeStatus.SUCCESS;
        }

        // not RUNNING or SUCCESS, so increment Current Node
        Current++;

        if (Current >= children.Length)
        {

            Current = 0;
            return NodeStatus.FAILURE;
        }

        return NodeStatus.RUNNING;

    }

}
