
using System;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public static readonly float MoveSpeed = 2f;
    public static readonly float ChaseSpeed = 4f;
    public static readonly float FireInterval = 3f;

    public static ContactFilter2D PLAYER;

    private MonsterStateMachine _sm;

    [NonSerialized] public Animator _anim;
    [NonSerialized] public Rigidbody2D _rb;
    public CircleCollider2D _sightCollider;

    public GameObject ProjectilePrefab;
    public Transform FirePoint;
    public PropagateAnimation PropagateAnimation;

    private int _orient;
    public int Orient
    {
        get => (int)transform.right.x;
        set
        {
            if (value != 1 && value != -1) return;
            if (_orient == value) return;
            _orient = value;
            transform.Rotate(0, 180, 0);
        }
    }

    public void SetOrientToTarget() => Orient = (int)(_sm._target.position - transform.position).x;

    public Vector2 Velocity
    {
        get => _rb.velocity;
        set => _rb.velocity = value;
    }

    public void SetVelocityX(float x)
    {
        Velocity = new Vector2(x, Velocity.y);
    }

    public void SetVelocityY(float y)
    {
        Velocity = new Vector2(Velocity.x, y);
    }

    private Collider2D[] _resultsCache;

    private void Awake()
    {
        PLAYER = new ContactFilter2D()
        {
            layerMask = LayerMask.GetMask("Player"),
            useLayerMask = true,
            useTriggers = true,
        };

        _anim = GetComponentInChildren<Animator>();
        _rb = GetComponent<Rigidbody2D>();

        PropagateAnimation.AnimationFinishedEvent += AnimationFinished;

        _sm = new MonsterStateMachine(this);

        _orient = Orient;

        _resultsCache = new Collider2D[20];
    }

    private void Update()
    {
        if(_sm._target == null) _sm._target = CalcTarget();
        _sm.Update();
    }

    private void FixedUpdate()
    {
        _sm.FixedUpdate();
    }

    private Transform CalcTarget()
    {
        int n = _sightCollider.OverlapCollider(PLAYER, _resultsCache);
        for (int i = 0; i < n; i++)
        {
            return _resultsCache[i].transform;
        }

        return null;
    }

    public bool TargetInSight()
    {
        int n = _sightCollider.OverlapCollider(PLAYER, _resultsCache);
        for (int i = 0; i < n; i++)
        {
            if (_resultsCache[i].transform == _sm._target) return true;
        }

        return false;
    }

    private void AnimationFinished()
    {
        _sm.AnimationFinished();
    }
}
