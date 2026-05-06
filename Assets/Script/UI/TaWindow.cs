using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 创建3个防御塔的 UI窗口
/// </summary>
public class TaWindow : MonoBehaviour
{
    public static TaWindow Instance;

    private Button Ta1;
    private Button Ta2;
    private Button Ta3;

    public Grid cutGeZi;
    void Awake()
    {
        Instance = this;
    }
    public void ShowTaWindow(Grid geZi) //显示UI
    {
        this.cutGeZi = geZi;
        gameObject.SetActive(true);
        transform.position=geZi.transform.position;
    }

}
