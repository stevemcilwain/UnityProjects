
/// <summary>
/// An Action node (aka Leaf) has no children Nodes and interacts with the game
/// </summary>
public class ActionNode : Node
{
    public override NodeStatus Tick(BehaviorState state)
    {
        return Status;
    }
}
