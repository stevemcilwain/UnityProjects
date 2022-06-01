
/// <summary>
/// A composite node is parent to one or more children nodes.
/// </summary>
public class CompositeNode : Node
{
    public int Current;

    protected Node[] children;

    protected virtual void Awake()
    {
        children = GetChildrenNodes();
        AssertChildren(children);
    }

    public override NodeStatus Tick(BehaviorState state)
    {
        return children[Current].Tick(state);
    }

}

