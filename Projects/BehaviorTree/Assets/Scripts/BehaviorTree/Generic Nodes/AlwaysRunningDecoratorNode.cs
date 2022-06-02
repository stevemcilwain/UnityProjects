
public class AlwaysRunningDecoratorNode : DecoratorNode
{
    public override NodeStatus Tick(BehaviorState state)
    {
        child.Tick(state);

        return NodeStatus.RUNNING;
    }

}
