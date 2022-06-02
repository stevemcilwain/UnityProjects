
public class AlwaysSucceedDecoratorNode : DecoratorNode
{

    public override NodeStatus Tick(BehaviorState state)
    {
        child.Tick(state);

        return NodeStatus.SUCCESS;
    }

}
