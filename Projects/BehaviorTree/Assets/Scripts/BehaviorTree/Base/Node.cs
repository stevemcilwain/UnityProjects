
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Node class is the base class of all other node types in the BehaviorTree
/// </summary>
public class Node : MonoBehaviour
{
    // Inspector Settings

    public NodeStatus Status = NodeStatus.RUNNING;
    public bool DebugNode;

    // Implementation Function

    public virtual NodeStatus Tick(BehaviorState state) { return Status; }

    // Base Class Utility Methods

    public Node GetChildNode()
    {
        if (transform.childCount > 0)
            return transform.GetChild(0).GetComponent<Node>();

        return null;
    }

    public Node[] GetChildrenNodes()
    {
        Node[] children = null;

        if (transform.childCount > 0)
        {
            var nodes = new List<Node>();

            foreach (Transform childTransform in transform)
            {
                var child = childTransform.gameObject.GetComponent<Node>();
                nodes.Add(child);
            }

            children = nodes.ToArray();
        }

        return children;
    }

    public void Log(string message)
    {
        if (DebugNode) Debug.LogFormat(gameObject, "{0}: {1} ", gameObject.name, message);
    }

    public void LogWarning(string message)
    {
        if (DebugNode) Debug.LogWarningFormat(gameObject, "{0}: {1} ", gameObject.name, message);
    }

    public void LogError(string message)
    {
        if (DebugNode) Debug.LogErrorFormat(gameObject, "{0}: {1} ", gameObject.name, message);
    }

    public void AssertChild(Node child)
    {
        if (child == null)
        {
            Debug.LogFormat(gameObject, "{0} is missing a child Node", gameObject.name);
            if (DebugNode) Debug.Break();
        }
    }

    public void AssertChildren(Node[] children)
    {
        if (children == null)
        {
            Debug.LogFormat(gameObject, "{0} is missing one or more children Nodes", gameObject.name);
            if (DebugNode) Debug.Break();
        }
    }

}
