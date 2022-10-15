
public class AeroMotionState : MotionState
{
    public AeroMotionState(MotionStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _sm._canJump = false;
    }

    public override void Update()
    {
        base.Update();

        Player.Instance.Orient = InputManager.XInput;
        Player.Instance.SetVelocityX(InputManager.XInput * Player.MoveSpeed, Player.AeroSmoothTime);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_sm._grounded)
        {
            if (InputManager.XInput == 0)
            {
                _sm.SetState(_sm.IDLE);
            }
            else
            {
                _sm.SetState(_sm.MOVE);
            }
            return;
        }
    }
}
