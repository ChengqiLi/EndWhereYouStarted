
public class JumpMotionState : MotionState
{
    public JumpMotionState(MotionStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _sm._canJump = false;
        Player.Instance.SetVelocityY(Player.JumpVelocity);
    }

    public override void Update()
    {
        base.Update();
        _sm.SetState(_sm.AERO);
    }
}
