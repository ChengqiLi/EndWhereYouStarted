
public class MonsterState
{
    protected MonsterStateMachine _sm;
    public bool _animationFinished;

    public MonsterState(MonsterStateMachine sm)
    {
        _sm = sm;
    }

    public virtual void Enter()
    {
        _animationFinished = false;
    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {

    }
}
