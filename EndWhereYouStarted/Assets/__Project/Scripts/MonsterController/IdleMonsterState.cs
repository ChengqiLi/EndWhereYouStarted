
public class IdleMonsterState : MonsterState
{
    private int _orient;

    public IdleMonsterState(MonsterStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();

        _sm._monster._anim.Play("idle");
    }

    public override void Update()
    {
        base.Update();

        if(_sm._target != null) _sm._monster.SetOrientToTarget();
        _sm._monster.SetVelocityX(0);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_sm._target != null)
        {
            if (_sm.CanFire())
            {
                _sm.SetState(_sm.FIRE);
                return;
            }
            else if(!_sm._monster.TargetInSight())
            {
                _sm.SetState(_sm.MOVE);
                return;
            }
        }
    }
}
