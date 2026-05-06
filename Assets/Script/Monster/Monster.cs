using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public enum MonsterType
{
    Common,
    Special,
    Boos,
}
public class Monster : BaseObject
{
    protected AudioSource audioSource;
    public MonsterType monsterType;
    protected NavMeshAgent agent;
    protected Transform image;
    public float retardTime=1.5f;//减速时间
    protected float speed;//移动速度

    protected BaseObject target;
    public override void Start()  //初始化怪物数据
    {
        base.Start();
        audioSource = transform.GetComponent<AudioSource>();
        audioSource.volume = Config.Instance.attackSound;
        agent = transform.GetComponent<NavMeshAgent>();
        image = transform.GetChild(0);
        speed = agent.speed;
        //attackSpeed = AttackSpeed;
        if (target)
        {
            agent.SetDestination(target.transform.position);
        }
    }
    public void Init(BaseObject target)
    {
        this.target= target; 
    }

    // Update is called once per frame
   public virtual void  Update()
    {
        if (target != null)
        {
            float dis = Vector3.Distance(transform.position, target.transform.position);
            if (dis <= 0.5f)
            {
                GameObject.Destroy(gameObject);
                GameObject.Destroy(wordUIHP.gameObject);
                target.Harm(1);
                audioSource.Play();
            }
        }
        image.transform.eulerAngles = new Vector3(90, 0, 0);

        if ((retardTime-=Time.deltaTime)<=0) //只能减速 5秒 5秒后回复正常速度
        {
            agent.speed = speed;
        }

    }
    public override void Harm(float v)
    {
        base.Harm(v);
        if (hp<=0)
        {
            MonsterManger.Instance.cutMonstr.Remove(this);
             CombatInfoWindow.Instance.SetGold(3);
        }
    }
    public void ReplyHp()  //基地回复满血 就是血瓶 道具调用的地方
    {
        hp = maxHp;
        wordUIHP.SetHp(hp / maxHp);
    }
    public void SetSpeed(float retardSpeed,float retardTime=1.5f) //设置减速的地方  减速子弹调用的地方
    {
        if (agent != null)
        {
            float newSpeed = speed * retardSpeed;
            if ((speed - newSpeed) < agent.speed)
            {
                agent.speed = speed - newSpeed;
            }
            this.retardTime = retardTime;
        }
    }
}
