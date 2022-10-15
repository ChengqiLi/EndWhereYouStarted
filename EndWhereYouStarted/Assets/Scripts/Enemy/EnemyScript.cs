using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    
    public float speed;

    public Transform pointL;
    public Transform pointR;
    public Transform targetPoint;

    public List<Transform> attackList = new List<Transform>();//记录要攻击的玩家位置/炸弹位置

    EnemyBaseState currentState;//当前状态
    public XunLuoState xunLuoState = new XunLuoState();
    public AttackState attackState = new AttackState();

    public Animator anim;
    public int animState;

    private float nextAttack = 0;
    public float attackCD;
    public float attackLength;
    public float skillLength;

    [Header("Health")]
    public float health;
    public bool isDead;


    private GameObject surpriseSign;
    public virtual void Init()
    {
        anim = GetComponent<Animator>();
        surpriseSign = transform.GetChild(0).gameObject;
    }

    private void Awake()
    {
        Init();
    }
    void Start()
    {
        TransitionToState(xunLuoState);//切换到巡逻状态
        /*巡逻状态：进入状态实现
         * SwitchPoint();
         */
    }

    
    void Update()
    {
        anim.SetBool("dead", isDead);
        if (isDead) return;
        currentState.OnState(this);//巡逻状态：状态中实现
        /*巡逻状态：状态中实现
        //if（快到达目标点的时候）
        if(Mathf.Abs(transform.position.x-targetPoint.position.x)<0.1f)
        {
            SwitchPoint();//切换目标点
        }
        MoveToTarget();
        */
        anim.SetInteger("state", animState);//每一帧同步状态值
    }
    
    
    
    public void TransitionToState(EnemyBaseState state)//切换状态
    {
        currentState = state;
        currentState.EnterState(this);//进入当前状态 this是什么？this是当前EnemyScript脚本对象
    }
    
    
    
    public void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);
        ZhuanXiang();
    }
    
    
    
    public virtual void AttackAction()//攻击玩家
    {
        Debug.Log("发现玩家，攻击玩家");
        
        if(Vector2.Distance(transform.position,targetPoint.position)<attackLength)
        {
            if(Time.time>nextAttack)
            {

                //Debug.Log("播放攻击效果");
                anim.SetTrigger("attack");
                nextAttack = Time.time + attackCD;
            }
        }
    }
    
    
    
    public virtual void SkillAction()//技能
    {
        //Debug.Log("发现炸弹，使用技能");

        if (Vector2.Distance(transform.position, targetPoint.position) < skillLength)
        {
            if (Time.time > nextAttack)
            {
                Debug.Log("播放技能效果");
                anim.SetTrigger("skill");
                nextAttack = Time.time + attackCD;
            }
        }
    }
    
    
    
    public void ZhuanXiang()//敌人转向（翻转）
    {
        if(transform.position.x<targetPoint.position.x)//如果目标点在右侧
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);//欧拉角旋转置为（0，0，0）即初始朝向向右

        }
        else
        {
            transform.rotation = Quaternion.Euler(0,180, 0);
        }
    }
    
    
    
    public void SwitchPoint()
    {
        //把目标点设置为较远的那个点
        
        if(Mathf.Abs(pointL.position.x-transform.position.x)>Mathf.Abs(pointR.position.x-transform.position.x))
        {
            targetPoint = pointL;
        }
        else
        {
            targetPoint = pointR;
        }
    }
    
    
    public void OnTriggerStay2D(Collider2D collision)
    {
        //如果攻击队列里面没有这个物体的坐标，则添加
        if(attackList.Contains(collision.transform)==false)
        {
            attackList.Add(collision.transform);
        }
    }
    
    public void OnTriggerExit2D(Collider2D collision)
    {
        attackList.Remove(collision.transform);
    }
    IEnumerator OnSurprise()
    {
        surpriseSign.SetActive(true);
        yield return new WaitForSeconds(surpriseSign.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length);
        surpriseSign.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(OnSurprise());
    }
}
