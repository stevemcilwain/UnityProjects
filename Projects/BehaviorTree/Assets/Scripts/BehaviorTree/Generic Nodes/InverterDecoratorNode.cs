

public class InverterDecoratorNode : DecoratorNode
{

    public override NodeStatus Tick(BehaviorState state)
    {
        var result = child.Tick(state);

        if (result == NodeStatus.SUCCESS) return NodeStatus.FAILURE;

        if (result == NodeStatus.FAILURE) return NodeStatus.SUCCESS;

        return NodeStatus.RUNNING;

    }
}
