
using UnityEngine;

public class MonsterStateMachine
{
    public IdleMonsterState IDLE;
    public MoveMonsterState MOVE;
    public FireMonsterState FIRE;
    public DamagedMonsterState DAMAGED;
    public DeathMonsterState DEATH;

    private MonsterState[] _states;
    private MonsterState _current;

    public Monster _monster;

    public float _firedTime;

    public bool CanFire() => _firedTime + Monster.FireInterval < Time.time;

    public Transform _target;

    public MonsterStateMachine(Monster monster)
    {
        _monster = monster;
        _states = new MonsterState[]
        {
            IDLE = new IdleMonsterState(this),
            MOVE = new MoveMonsterState(this),
            FIRE = new FireMonsterState(this),
            DAMAGED = new DamagedMonsterState(this),
            DEATH = new DeathMonsterState(this),
        };

        _current = IDLE;

        _target = null;
    }

    public void SetState(MonsterState state)
    {
        _current.Exit();
        _current = state;
        _current.Enter();
    }

    public void Update()
    {
        _current.Update();
    }

    public void FixedUpdate()
    {
        _current.FixedUpdate();
    }

    public void AnimationFinished()
    {
        _current._animationFinished = true;
    }
}
