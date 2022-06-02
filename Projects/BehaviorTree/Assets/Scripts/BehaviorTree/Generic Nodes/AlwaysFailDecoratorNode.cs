
public class AlwaysFailDecoratorNode : DecoratorNode
{

    public override NodeStatus Tick(BehaviorState state)
    {
        child.Tick(state);

        return NodeStatus.FAILURE;
    }

}

