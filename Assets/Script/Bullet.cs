using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.PlayerSettings;

public class Bullet : MonoBehaviour  //子弹
{
    private Animator _animator;
    private AudioSource audioSource;
    public float speed=2;
    protected BaseObject target;
    public int attack;

    Vector3 pos;
    public bool isAttack=false ;
    // Start is called before the first frame update
    public void Init(BaseObject monster)
    {
        _animator =transform.GetChild(0). GetComponent<Animator>();
        audioSource = transform.GetComponent<AudioSource>();
        audioSource.volume = Config.Instance.attackSound;
        target = monster;//设置子弹目标 
                         // this.attack = attack; //设置子弹攻击
        GameObject.Destroy(gameObject,5);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        if (target) //如果当前目标 死亡  旧把死亡的地方当作射击点
        {
            pos = target.transform.position;
        }
        if (pos!=Vector3.zero) //射击点的 位置 不为0，0，0
        {

            float dis = Vector3.Distance(transform.position, pos);
            if (dis < 0.25f&&isAttack==false )  //子弹和目标小于0.25 旧伤害目标
            {
                isAttack = true;
                _animator.SetTrigger("Attack");
                Run();
            }
            else
            {
                transform.LookAt(pos); //朝向目标
                transform.Translate(transform.forward * speed * Time.deltaTime, Space.World); //射击目标
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public virtual void Run()//执行子弹逻辑
    {
        StartCoroutine(Hide());
        if (target)
        {
            target.Harm(attack);
        }
    }
    public IEnumerator Hide()
    {
        audioSource.Play();
        yield return new WaitForSeconds(1);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
