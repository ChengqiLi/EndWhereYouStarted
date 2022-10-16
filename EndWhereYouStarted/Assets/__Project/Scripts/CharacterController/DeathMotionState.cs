
public class DeathMotionState : MotionState
{
    public DeathMotionState(MotionStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.Instance._anim.Play("dead");
    }
}
