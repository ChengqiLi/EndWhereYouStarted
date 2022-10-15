
using UnityEngine;

public class Player : MonoBehaviour
{
    public static readonly float MoveSpeed = 6;
    public static readonly float MoveSmoothTime = 0.05f;
    public static readonly float AeroSmoothTime = 0.2f;
    public static readonly float JumpTime = 4f;
    public static readonly float JumpHeight = 30f;
    public static readonly float JumpCancelSpeedScale = 0.5f;
    public static readonly float MaxFallSpeed = -10f;

    public static float JumpVelocity;
    public static float Gravity;

    public static ContactFilter2D GROUND;

    private static Player _instance;
    public static Player Instance => _instance;

    public GameObject ProjectilePrefab;
    public Transform FirePoint;

    private Rigidbody2D _rb;
    private BoxCollider2D _collider;

    private MotionStateMachine _sm;
    private PlayerWeapon _weapon;

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

    public void SetVelocityX(float x, float t)
    {
        SetVelocityX(Mathf.SmoothDamp(Velocity.x, x, ref _velocityRef, t));
    }

    private float _velocityRef;
    private ContactPoint2D[] _resultsCache;

    private void Awake()
    {
        Gravity = 2 * JumpHeight / Mathf.Pow(JumpTime, 2);
        JumpVelocity = Gravity * JumpTime;

        GROUND = new ContactFilter2D()
        {
            layerMask = LayerMask.GetMask("Ground"),
            useLayerMask = true,
            useTriggers = true,
        };

        _instance = this;

        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = Gravity;
        _collider = GetComponent<BoxCollider2D>();

        _sm = new MotionStateMachine();
        _weapon = new PlayerWeapon();

        _orient = (int)transform.right.x;
        _resultsCache = new ContactPoint2D[20];
    }

    private void Update()
    {
        _sm.Update();
        _weapon.Update();
    }

    private void FixedUpdate()
    {
        _sm._grounded = CalcGrounded();
        _sm.FixedUpdate();
    }

    private bool CalcGrounded()
    {
        int n = _collider.GetContacts(GROUND, _resultsCache);
        for (int i = 0; i < n; i++)
        {
            if (_resultsCache[i].normal.y > 0.9f) return true;
        }
        return false;
    }
}
