using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour,IDamageable
{
    private Rigidbody2D rb;
    private float speed=5;
    private float jumpForce=20;



    public bool isJumping;
    public bool canJump;
    private float checkRadius=0.5f;//注意这个值一定要很小
    public bool isGround;
    public Transform groundCheck;
    public LayerMask groundLayer;

    public GameObject jumpFX;
    public GameObject fallFX;

    public GameObject bombPrefab;
    public float nextAttack = 0;
    public float attackCD;

    [Header("PlayerState")]
    public float health;
    public bool isDead = false;
    private Animator anim;

    private FixedJoystick joystick;
    public static PlayerScript Instance;
    public void Attack()
    {
        if(Time.time>nextAttack)
        {
            Debug.Log("Attack()");
            Instantiate(bombPrefab, transform.position, bombPrefab.transform.rotation);
            nextAttack = Time.time + attackCD;
        }
    }
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        joystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    void Update()
    {
        anim.SetBool("dead", isDead);
        if (isDead) return;//如果死了，以下操作全部不执行
        CheckInput();
        
    }
    private void FixedUpdate()
    {
        if (isDead) {
            rb.velocity = Vector2.zero;
            return;
        };
        PhysicsCheck();
        Movement();
        Jump();
    }
    void Movement()
    {
        /*
        //float horizontalInput = Input.GetAxis("Horizontal");//获得水平输入,有小数，-1~1之间,右为正，左为负数
        float horizontalInput = Input.GetAxisRaw("Horizontal");//获得水平输入,无小数，-1~1之间,右为1，左为-1
        */
        //操作杆
        float horizontalInput = joystick.Horizontal;
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        Debug.Log(joystick.Horizontal);//joystick.Horizontal为-1到1的小数，-1为摇杆完全向左

        if (horizontalInput>0)//向右移动
        {
            transform.localScale = new Vector3(1, 1, 1);//不转向
        }
        else if(horizontalInput <0)//向左移动
        {
            transform.localScale = new Vector3(-1, 1, 1);//转向
        }
    }
    //专门检测输入
    
    void CheckInput()
    {
        if(Input.GetButtonDown("Jump")&&isGround)
        {
            canJump = true;
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }
    public void Jump()
    {
        if(canJump)
        {
            isJumping = true;//正在跳跃置为true
            jumpFX.SetActive(true);//播放起跳气流特效，激活
            jumpFX.transform.position = transform.position + new Vector3(0, -0.45f, 0);//播放位置是人物下方一点
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false;
        }
    }
    void PhysicsCheck()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position,checkRadius,groundLayer);//以圆形范围检测是否有地面
        if (isGround) isJumping = false;
    }
    public void OnDrawGizmos()//unity自带的，不需要在Update手动调用
    {
        Gizmos.DrawWireSphere(groundCheck.position, checkRadius);//画出检测范围
    }

    public void FallFinish()
    {
        fallFX.SetActive(true);//开始播放落地气流特效，激活
        fallFX.transform.position = transform.position + new Vector3(0, -0.6f, 0);//播放位置是人物下方一点
    }

    public void GetHit(float damage)
    {
        if (anim.GetCurrentAnimatorStateInfo(1).IsName("Player_hit")==false)//受伤后短暂无敌
        {
            health = health - damage;
            anim.SetTrigger("hit");

        }
        if (health <= 0.1f)
        {
            health = 0;
            isDead = true;
        }
        UIManagerScript.Instance.UpdateHealth(health);
    }
}
