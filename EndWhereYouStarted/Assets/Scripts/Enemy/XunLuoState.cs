using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XunLuoState : EnemyBaseState
{
    public override void EnterState(EnemyScript enemy)
    {
        enemy.animState = 0;
        enemy.SwitchPoint();
        Debug.Log("进入了巡逻状态！");
    }

    public override void OnState(EnemyScript enemy)
    {
        Debug.LogWarning("巡逻状态持续中");
        //需求：播放完idle再移动
        //enemy.anim.GetCurrentAnimatorStateInfo(动画层号).IsName("动画名")
        //获取该动画的状态，判断是否在那个动画状态，是返回true，不是返回false
        if (enemy.anim.GetCurrentAnimatorStateInfo(0).IsName("idle") == false)
        {

            enemy.animState = 1;
            enemy.MoveToTarget();

        }
        //if（快到达目标点的时候）
        if (Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x) < 0.5f)
        {
            enemy.SwitchPoint();//切换目标点
            Debug.Log(enemy.targetPoint);
            enemy.TransitionToState(enemy.xunLuoState);
        }
        if(enemy.attackList.Count>0)//如果攻击队列里面有人，则进入攻击状态
        {
            enemy.TransitionToState(enemy.attackState);
        }
        
    }
}
