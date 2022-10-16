
using UnityEngine;

public class AeroMotionState : MotionState
{
    private static readonly int AeroBlend = Animator.StringToHash("aeroBlend");

    public AeroMotionState(MotionStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _sm._canJump = false;
        Player.Instance._anim.Play("aero");
    }

    public override void Update()
    {
        base.Update();

        Player.Instance.Orient = InputManager.XInput;
        Player.Instance.SetVelocityX(InputManager.XInput * Player.MoveSpeed, Player.AeroSmoothTime);
        float blend = (Mathf.Sign(Player.Instance.Velocity.y) + 1) / 2;
        Player.Instance._anim.SetFloat(AeroBlend, blend);
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
