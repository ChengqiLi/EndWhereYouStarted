
using UnityEngine;

public abstract class MotionState
{
    protected MotionStateMachine _sm;
    protected float _startTime;

    protected MotionState(MotionStateMachine sm)
    {
        _sm = sm;
    }

    public virtual void Enter()
    {
        _startTime = Time.time;
    }

    public virtual void Exit() { }
    public virtual void Update() { }
    public virtual void FixedUpdate() { }
}
