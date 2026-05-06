using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettlementWindow : MonoBehaviour
{
    public  static SettlementWindow Instance;
    private Transform shengli;
    private Transform shiBai;
    private Transform shengli1;
    private  Transform shengli2;

    private Button fanhui;
    private Button restart;
    private Button nextStage;
    private void Awake()
    {
        Instance = this;
        shengli = transform.Find("ShengLi");
        shiBai = transform.Find("ShiBai");
        shengli1 = transform.Find("ShengLi1");
        shengli2 = transform.Find("ShengLi2");
        
        restart = transform.Find("Restart").GetComponent<Button>();
        nextStage = transform.Find("NextStage").GetComponent<Button>();
        fanhui = transform.Find("fanhui").GetComponent<Button>();
        
        fanhui.onClick.AddListener((() =>
        {
            SceneManager.LoadScene("0");
        }));
        restart.onClick.AddListener((() =>
        {
            SceneManager.LoadScene("1");
        }));
        nextStage.onClick.AddListener((() =>
        {
               //下一关// SceneManager.LoadScene("1");
        }));
        transform.gameObject.SetActive(false);
    }

    public void ShengLi()
    {
        transform.gameObject.SetActive(true);
        shengli.gameObject.SetActive(true);
        shiBai.gameObject.SetActive(false);
        shengli1.gameObject.SetActive(false);
        shengli2.gameObject.SetActive(false);
    }

    public void ShiBai()
    {
        transform.gameObject.SetActive(true);
        shiBai.gameObject.SetActive(true);
        shengli.gameObject.SetActive(false);
        shengli1.gameObject.SetActive(false);
        shengli2.gameObject.SetActive(false);
    }
    
    public void ShengLi1()
    {
        transform.gameObject.SetActive(true);
        shengli1.gameObject.SetActive(true);
        shengli2.gameObject.SetActive(false);
    }
    
    public void ShengLi2()
    {
        transform.gameObject.SetActive(true);
        shengli2.gameObject.SetActive(true);
        shengli1.gameObject.SetActive(false);
    }
}
