
public class MotionStateMachine
{
    public IdleMotionState IDLE;
    public MoveMotionState MOVE;
    public JumpMotionState JUMP;
    public AeroMotionState AERO;
    public DamagedMotionState DAMAGED;
    public DeathMotionState DEATH;

    private MotionState[] _states;
    private MotionState _current;

    public bool _canJump;
    public bool _grounded;

    public MotionStateMachine()
    {
        _states = new MotionState[]
        {
            IDLE = new IdleMotionState(this),
            MOVE = new MoveMotionState(this),
            JUMP = new JumpMotionState(this),
            AERO = new AeroMotionState(this),
            DAMAGED = new DamagedMotionState(this),
            DEATH = new DeathMotionState(this),
        };

        _current = IDLE;
        _canJump = true;
    }

    public void SetState(MotionState state)
    {
        _current.Exit();
        _current = state;
        _current.Enter();
    }

    public void Update() => _current.Update();
    public void FixedUpdate() => _current.FixedUpdate();
}
