
using UnityEngine;

public class MoveMonsterState : MonsterState
{
    private int _randomedOrient;

    public MoveMonsterState(MonsterStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _sm._monster._anim.Play("walk");
        _randomedOrient = (int)Mathf.Sign(UnityEngine.Random.Range(0, 1) - 0.5f);
    }

    public override void Update()
    {
        base.Update();

        if (_sm._target == null)
        {
            _sm._monster.Orient = _randomedOrient;
            _sm._monster.SetVelocityX(_randomedOrient * Monster.MoveSpeed);
        }
        else
        {
            if (_sm._monster.TargetInSight())
            {
                _sm.SetState(_sm.IDLE);
                return;
            }
            else
            {
                _sm._monster.SetOrientToTarget();
                _sm._monster.SetVelocityX(_sm._monster.Orient * Monster.ChaseSpeed);
            }
        }
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        if (_sm._target != null && _sm.CanFire())
        {
            _sm.SetState(_sm.FIRE);
            return;
        }
    }
}
