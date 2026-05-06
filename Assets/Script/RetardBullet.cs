using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

//减速子弹 继承子弹基类
public class RetardBullet : Bullet
{
    public float sustainedTime;//持续伤害
    public float retardSpeed;//减速速度
    public float stopTime;
    public override void Run()//减速子弹的 逻辑
    {
        if (target)
        {
            target.Harm(attack);
            StartCoroutine(Hide());
            if (target.baseObjectType==BaseObjectType.Monster)
            {
                Monster monster = (Monster)target;
                monster.SetSpeed(1, stopTime);
            }                    
            StartCoroutine(enumerator());
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }
    public IEnumerator enumerator()
    {
        yield return new WaitForSeconds(stopTime);
        if (target.baseObjectType == BaseObjectType.Monster)
        {
            Monster monster = (Monster)target;
            monster.SetSpeed(retardSpeed, sustainedTime);
        }
        GameObject.Destroy(gameObject);
    }
}
