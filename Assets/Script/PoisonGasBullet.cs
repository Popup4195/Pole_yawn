using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGasBullet : Bullet
{
    public float retardSpeed;//减速速度
    public float sustainedInjury;//持续伤害
    public float sustainedTime;//持续时间
    private float harm;

    public void Awake()
    {
        harm = sustainedInjury / sustainedTime*Time.deltaTime;
    }
    public override void Run()
    {
        if (target)
        {
            target.Harm(attack);
            if (target.baseObjectType == BaseObjectType.Monster)
            {
                Monster monster = (Monster)target;
                monster.SetSpeed(retardSpeed, sustainedTime);
            }
            StartCoroutine(Hide());
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }
    public override void Update()
    {
        base.Update();
        if (isAttack) 
        {
            if (sustainedTime >= 0)
            {
                sustainedTime -= Time.deltaTime;
                if (target.GetHp() > 0)
                {
                    target.Harm(harm);
                }
            }
            else
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
