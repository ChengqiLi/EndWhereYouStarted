
public class MoveMotionState : MotionState
{
    public MoveMotionState(MotionStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _sm._canJump = true;
    }

    public override void Update()
    {
        base.Update();

        if (InputManager.XInput == 0)
        {
            _sm.SetState(_sm.IDLE);
            return;
        }

        if (_sm._canJump && InputManager._holdingJump)
        {
            _sm.SetState(_sm.JUMP);
            return;
        }

        Player.Instance.Orient = InputManager.XInput;
        Player.Instance.SetVelocityX(InputManager.XInput * Player.MoveSpeed, Player.MoveSmoothTime);
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
