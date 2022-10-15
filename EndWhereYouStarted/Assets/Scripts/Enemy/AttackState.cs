using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : EnemyBaseState
{
    public override void EnterState(EnemyScript enemy)
    {
        Debug.Log("进入了攻击状态");
        enemy.animState = 2;
        enemy.targetPoint = enemy.attackList[0];
    }

    public override void OnState(EnemyScript enemy)
    {
        //Debug.LogWarning("攻击状态持续中");
        if (enemy.attackList.Count == 0)//如果攻击队列没有目标则切换回巡逻状态
        {
            enemy.TransitionToState(enemy.xunLuoState);
        }
        if (enemy.attackList.Count > 1)//如果有两及以上目标
        {
            for (int i = 0; i < enemy.attackList.Count; i++)
            {
                if (//比较第i个元素与敌人的水平距离如果小于当前目标离敌人的距离，那么就把这个更近的元素作为目标
                    Mathf.Abs(enemy.transform.position.x - enemy.attackList[i].position.x)
                    < Mathf.Abs(enemy.transform.position.x - enemy.targetPoint.position.x)
                    )
                {
                    enemy.targetPoint = enemy.attackList[i];
                }
            }
        }
        if(enemy.attackList.Count == 1) enemy.targetPoint = enemy.attackList[0];
        if(enemy.targetPoint.CompareTag("Player"))
        {
            enemy.AttackAction();//攻击玩家
        }
        if(enemy.targetPoint.CompareTag("Boom"))
        {
            enemy.SkillAction();//怪物放技能
        }
        enemy.MoveToTarget();
    }
}
