using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    [SerializeField]
    private Node tree;

    [SerializeField]
    private EnemyBehaviorState _state;

    private void Awake()
    {
        if (tree == null)
        {
            Debug.LogErrorFormat(gameObject, "{0}: BehaviorTree root node is not assigned in the inspector", name);
        }
    }

    private void Start()
    {
        // start the behavior tree, which in this case is a repeating node that runs
        // on an interval
        tree.Tick(_state);
    }

}
