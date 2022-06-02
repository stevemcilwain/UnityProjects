
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorState : BehaviorState
{


    public bool Moving;
    public Vector3 MovementDestination;

    public bool Chasing;
    public Transform Target;

    public override void Reset()
    {
        Target = null;
        Moving = false;
        MovementDestination = Vector3.zero;

    }
}
