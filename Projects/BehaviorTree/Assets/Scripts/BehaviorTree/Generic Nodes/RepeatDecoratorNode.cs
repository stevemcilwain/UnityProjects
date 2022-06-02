using System.Collections;
using UnityEngine;

public class RepeatDecoratorNode : DecoratorNode
{

    [Range(1, 1000)]
    public int Repetitions = 1;

    [Range(0.1f, 300.0f)]
    public float IntervalSeconds = 1.0f;

    public bool Infinite;

    private WaitForSeconds _wait;
    private bool _isRunning;
    private bool _isStarted;
    private int _reps;

    private NodeStatus _finalResult;

    protected override void Awake()
    {
        base.Awake();
        _wait = new WaitForSeconds(IntervalSeconds);
    }

    public override NodeStatus Tick(BehaviorState state)
    {
        if (_isRunning)
        {
            return NodeStatus.RUNNING;
        }
        else
        {
            if (!_isStarted)
            {
                Log("Starting: " + child.name + " Repitions: " + Repetitions);
                StartCoroutine(Repeat(state));
                _isStarted = true;
                _isRunning = true;
                return NodeStatus.RUNNING;
            }
            {
                Log("Completed " + _reps + " repetitions of: " + child.name);

                //reset state
                _isStarted = false;
                _reps = 0;

                return _finalResult;
            }
        }
    }

    private IEnumerator Repeat(BehaviorState state)
    {
        bool loop = true;

        while (loop)
        {
            _finalResult = child.Tick(state);

            if (_finalResult != NodeStatus.RUNNING)
            {
                Log(child.name + " returned " + _finalResult);
                _reps++;
            }

            if (!Infinite)
            {
                if (_reps >= Repetitions)
                {
                    loop = false;
                }
            }

            yield return _wait;
        }

        _isRunning = false;
    }

}
