using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobmScript : MonoBehaviour
{
    private Animator anim;
    public float startTime;
    public float waitTime;
    public float radius;
    public LayerMask targetLayer;//目标层：想要爆炸作用的层
    public float bobmForce;
    private Collider2D coll;
    private Rigidbody2D rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        startTime = Time.time;//开始计算时间=游戏经历时间
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("BobmOff") ==false)//如果不是在播放炸弹熄灭动画
        {
            if (Time.time > startTime + waitTime)
            {
                anim.Play("BombExplotion");//播放爆炸动画
            }
        }
    }
    public void OnDrawGizmos()//unity自带的，不需要在Update手动调用
    {
        Gizmos.DrawWireSphere(transform.position, radius);//画出范围
    }

    public void Explotion()//Animation Event,在爆炸动画结束的最后一帧调用
    {
        coll.enabled = false;//防止炸到自己
        rb.gravityScale = 0;//在取消激活碰撞体之后，会掉落
        Collider2D[] collider2Ds = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);
        
        foreach(var item in collider2Ds)
        {
            Vector3 offset = transform.position - item.transform.position;//计算物体与炸弹的相对位置
            if (item == null) return;
            item.GetComponent<Rigidbody2D>().AddForce((-offset+Vector3.up) * bobmForce, ForceMode2D.Impulse);
            //Debug.Log(item.gameObject.name);
            if(item.CompareTag("Boom")&&
                item.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("BobmOff") == true
                )//如果被炸到的是炸弹，并且它是在熄灭动画状态
            {
                item.GetComponent<BobmScript>().TurnOn();
            }
            if(item.CompareTag("Player"))
            {
                item.GetComponent<IDamageable>().GetHit(1);
            }
        }
    }
    public void FinishDestroy()
    {
        Destroy(gameObject);
        Debug.Log("FinishDestroy()");
    }
    public void TurnOff()
    {
        anim.Play("BobmOff");
        gameObject.layer = LayerMask.NameToLayer("NPC");//修改图层，移除出敌人的攻击列表
    }
    public void TurnOn()
    {
        startTime = Time.time;
        anim.Play("BobmOn");
        gameObject.layer = LayerMask.NameToLayer("Bobm");//修改图层，可以进入敌人的攻击列表
    }
}
