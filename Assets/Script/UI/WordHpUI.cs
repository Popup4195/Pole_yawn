using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 世界UI 血条
/// </summary>

public class WordHpUI : MonoBehaviour
{
    Transform target;
    Image hp;
    private Vector3 height;
    // Start is called before the first frame update
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="monster"></param>
    public void Init(Transform target)
    {
        this.target = target;
        hp = transform.Find("hp").GetComponent<Image>();
    }

    /// <summary>
    /// 跟随怪物 ，朝向摄像头
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (target!=null )
        {
            transform.position = target.position+height;
          //  transform.LookAt(Camera.main.transform.position);
        }
    }
    /// <summary>
    /// 设置血条
    /// </summary>
    /// <param name="hp"></param>
    public void SetHp(float hp)
    {
        this.hp.fillAmount = hp;
    }
    public void SetHeight(Vector3 height)
    {
        this.height = height;
    }
}
