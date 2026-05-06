using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpecialMonster : Monster
{
    public float AttackSpeed = 1.5f;
    public float attack;
    protected float attackSpeed;
    protected Tower tower;
    protected Vector3 oldPos;

    // Update is called once per frame
    public override void Update()
    {
        if (target != null && tower == null)
        {
            if (oldPos != Vector3.zero)
            {
                float oldPosDis = Vector3.Distance(transform.position, oldPos);
                if (oldPosDis <= 0.1f)
                {
                    oldPos = Vector3.zero;
                    agent.enabled = true;
                    agent.SetDestination(target.transform.position);
                }
                else
                {
                    transform.LookAt(oldPos);
                    transform.Translate(transform.forward * 1 * Time.deltaTime, Space.World);
                }
            }

            float dis = Vector3.Distance(transform.position, target.transform.position);
            if (dis <= 0.5f)
            {
                GameObject.Destroy(gameObject);
                GameObject.Destroy(wordUIHP.gameObject);
                target.Harm(1);
            }
        }
        image.transform.eulerAngles = new Vector3(90, 0, 0);

        if ((retardTime -= Time.deltaTime) <= 0) //ֻ�ܼ��� 5�� 5���ظ������ٶ�
        {
            agent.speed = speed;
        }
        //�п��Թ�������ʱ��
        if (tower)
        {
            float dis = Vector3.Distance(transform.position, tower.transform.position);
            if (dis <= 1.5f)
            {
                agent.enabled = false;
                transform.LookAt(tower.transform.position);
                if (oldPos == Vector3.zero)
                {
                    oldPos = transform.position;
                }
                if (dis <= 0.5f)
                {
                    if ((attackSpeed -= Time.deltaTime) <= 0)
                    {
                        attackSpeed = AttackSpeed;
                        Attack();
                    }
                }
                else
                {
                    transform.Translate(transform.forward * 1 * Time.deltaTime, Space.World);
                }
            }
            else
            {
                if (oldPos != Vector3.zero)
                {
                    float oldPosDis = Vector3.Distance(transform.position, oldPos);
                    if (oldPosDis <= 0.1f)
                    {
                        oldPos = Vector3.zero;
                        agent.enabled = true;
                        agent.SetDestination(target.transform.position);
                    }
                    else
                    {
                        transform.LookAt(oldPos);
                        transform.Translate(transform.forward * 1 * Time.deltaTime, Space.World);
                    }
                }
            }
        }
    }

    protected void Attack()
    {
        tower.Harm(attack);
        if (tower.GetHp()<=0)
        {
            CombatInfoWindow.Instance.RemoveTower(tower);
        }
        audioSource.Play();
    }

    public void OnTriggerStay(Collider other)
    {
        if (this.tower)
        {
            return;
        }
        Tower tower = other.GetComponent<Tower>();
        if (tower && tower.baseObjectType == BaseObjectType.DefenseTower)
        {
            this.tower = tower;
        }

    }
    public override void Harm(float v)
    {
        hp -= v;
        if (hp <= 0)
        {
            if (this.wordUIHP)
            {
                GameObject.Destroy(this.wordUIHP.gameObject);
                GameObject.Destroy(this.gameObject);
            }
        }
        else
        {
            wordUIHP.SetHp(hp / maxHp);
        }
        if (hp <= 0)
        {
            MonsterManger.Instance.cutMonstr.Remove(this);
            CombatInfoWindow.Instance.SetGold(5);
        }
    }
}
