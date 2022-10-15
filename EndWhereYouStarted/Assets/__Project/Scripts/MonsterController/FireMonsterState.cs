
using UnityEngine;

public class FireMonsterState : MonsterState
{
    public FireMonsterState(MonsterStateMachine sm) : base(sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _sm._monster._anim.Play("attack");
    }

    private void Fire()
    {
        _sm._firedTime = Time.time;

        Vector2 target = _sm._target.position + Vector3.up;
        Vector2 firePointPosition = _sm._monster.FirePoint.position;

        Vector3 vectorToTarget = target - firePointPosition;
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * vectorToTarget;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, rotatedVectorToTarget);
        GameObject.Instantiate(_sm._monster.ProjectilePrefab, firePointPosition, rotation);
    }

    public override void Update()
    {
        base.Update();
        if (_animationFinished)
        {
            Fire();
            _sm.SetState(_sm.IDLE);
            return;
        }

        _sm._monster.SetOrientToTarget();
        _sm._monster.SetVelocityX(0);
    }
}
