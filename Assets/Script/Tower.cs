using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//防御塔
public class Tower : BaseObject
{
    public int id;
    public int price;
    public int level;
    public float AttackSpeed;
    public float AttackDis;

    private float attackSpeed;
    public Bullet bullet; 
    private SphereCollider sphereCollider;

    private List<Monster> monsters = new List<Monster>();
    private List<Barrier> barrierList = new List<Barrier>();
    // Start is called before the first frame update
    public override void Start()
    {
        if (baseObjectType==BaseObjectType.DefenseTower)
        {
            base.Start();
        }

        bullet = transform.GetChild(1).GetComponent<Bullet>();
        sphereCollider = transform.GetComponent<SphereCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((attackSpeed-=Time.deltaTime)<=0) //攻击间隔时间
        {
            AttackMonster(); //攻击目标
        }
    }

    private void AttackMonster() //攻击
    {
        attackSpeed = AttackSpeed;
        if (monsters.Count>0)
        {
            Monster monster = monsters[0];
            if (monster == null) 
            {
                monsters.Remove(monster); //怪物删除  要攻击怪物集合里面删除
            }
            if (monsters.Count>0)
            {
                monster = monsters[0];  //要攻击怪物集合里面 的第一个怪物
                Bullet go = GameObject.Instantiate(bullet);
                go.transform.position = bullet.transform.position;
                go.Init(monster);
                go.gameObject.SetActive(true);
            }
            return;
        }

        if (barrierList.Count>0)
        {
            Barrier barrier = barrierList[0];
            if (barrierList.Count > 0)
            {
                barrier = barrierList[0];  //要攻击怪物集合里面 的第一个怪物
                Bullet go = GameObject.Instantiate(bullet);
                go.transform.position = bullet.transform.position;
                go.Init(barrier);
                go.gameObject.SetActive(true);
            }
        }
    }


    private void OnTriggerEnter(Collider other)  //怪物进入射程  添加  要攻击怪物集合里面
    {
        Monster monster = other.GetComponent<Monster>();
        if (monster != null&&monster.baseObjectType == BaseObjectType.Monster) 
        {
            monsters.Add(monster);
        }
        Barrier barrier = other.GetComponent<Barrier>();
        if (barrier!=null&&barrier.baseObjectType==BaseObjectType.Barrier)
        {
            barrierList.Add(barrier);
        }
    }
    private void OnTriggerExit(Collider other)//怪物离开射程  删除  要攻击怪物集合里面
    {
        Monster monster = other.GetComponent<Monster>();
        if (monster != null && monster.baseObjectType == BaseObjectType.Monster)
        {
            monsters.Remove(monster);
        }
    }
}
