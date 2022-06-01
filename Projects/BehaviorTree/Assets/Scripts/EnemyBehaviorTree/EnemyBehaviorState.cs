
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorState : BehaviorState
{
    public Transform Target;

    public bool Moving;
    public Vector3 MovementDestination;

    public override void Reset()
    {
        Target = null;
        Moving = false;
        MovementDestination = Vector3.zero;

    }
}
