using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BaseObjectType
{
    None,
    DefenseTower,
    Tower,
    Monster,
    Barrier,
        Base,
}
public class BaseObject : MonoBehaviour
{
    public float maxHp;
    protected float hp;
    public BaseObjectType baseObjectType;
    protected WordHpUI wordUIHP;

    public virtual void Start()
    {
      //  baseObjectType = BaseObjectType.None;
        hp = maxHp;
        wordUIHP = WorldUIManager.Instance.GetWordHpUI(transform);
        wordUIHP.SetHeight(new Vector3(0,0,0.5f));
    }
    public virtual void Harm(float v)
    {
        hp -= v;
        if (hp <= 0)
        {
            if (baseObjectType==BaseObjectType.Base)
            {
                //SceneManager.LoadScene("0");
                SettlementWindow.Instance.ShiBai();
            }
            if (this.wordUIHP)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
        else
        {
            wordUIHP.SetHp(hp / maxHp);
        }
    }

    public float GetHp()
    {
        return hp;
    }
    public void OnDestroy()
    {
        if (this.wordUIHP)
        {
            GameObject.Destroy(this.wordUIHP.gameObject);
        }
    }
}
