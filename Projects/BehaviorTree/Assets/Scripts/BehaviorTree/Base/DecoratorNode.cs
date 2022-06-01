
/// <summary>
/// A DecoratorNode modifies the behavior of a single child node
/// </summary>
public class DecoratorNode : Node
{

    public Node child;

    protected virtual void Awake()
    {
        child = GetChildNode();
        AssertChild(child);
    }

    public override NodeStatus Tick(BehaviorState state)
    {
        return child.Tick(state);
    }


}
