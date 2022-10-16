
public class IdleMotionState : MotionState
{
    public IdleMotionState(MotionStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _sm._canJump = true;
        Player.Instance._anim.Play("idle");
    }

    public override void Update()
    {
        base.Update();

        if (InputManager.XInput != 0)
        {
            _sm.SetState(_sm.MOVE);
            return;
        }

        if (_sm._canJump && InputManager._holdingJump)
        {
            _sm.SetState(_sm.JUMP);
            return;
        }

        Player.Instance.SetVelocityX(0);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (!_sm._grounded)
        {
            _sm.SetState(_sm.AERO);
            return;
        }
    }
}
