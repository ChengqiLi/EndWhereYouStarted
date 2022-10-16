
public class DamagedMotionState : MotionState
{
    public DamagedMotionState(MotionStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.Instance._anim.Play("hit");
    }
}
