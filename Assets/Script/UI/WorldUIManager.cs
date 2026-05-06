using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 世界UI管理器
/// </summary>
public class WorldUIManager :MonoBehaviour
{
    public static WorldUIManager Instance;
    WordHpUI wordHpUI;

    public void Awake()
    {
        Instance = this;
        wordHpUI = Instantiate(Resources.Load<GameObject>("WordHpUI"), transform).AddComponent<WordHpUI>();
        wordHpUI.gameObject.SetActive(false);

    }
    /// <summary>
    /// 获取世界UI血条
    /// </summary>
    /// <param name="monster"></param>
    /// <returns></returns>
    public WordHpUI GetWordHpUI(Transform target)
    {
        WordHpUI wordHpUI= GameObject.Instantiate(this.wordHpUI, Vector3.zero, this.wordHpUI.transform.rotation, transform);
        wordHpUI.Init(target);
        wordHpUI.gameObject.SetActive(true);
        return wordHpUI;
    }

}
