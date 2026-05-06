using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CombatInfoWindow : MonoBehaviour
{
    public static CombatInfoWindow Instance { get; private set; }
    private Text info_text;
    private Text gold_Text;
    public int gold;
    public GameObject hintInfo;

    Transform stopWindow;
    Button stop;
    Button restart;
    Button exit;

    private List<Tower> towers = new List<Tower>();
    private int destroyNumber;

    public void Awake()
    {
        Instance = this;
        info_text = transform.Find("info_Image/info").GetComponent<Text>();
        gold_Text = transform.Find("glod").GetComponent<Text>();

        stopWindow = transform.Find("StopWindow");

        stop = stopWindow.Find("Stop").GetComponent<Button>();
        restart = stopWindow.Find("Restart").GetComponent<Button>();
        exit = stopWindow.Find("Exit").GetComponent<Button>();
        stop.onClick.AddListener(Stop);
        restart.onClick.AddListener(Restart);
        exit.onClick.AddListener( () =>
        {
            SceneManager.LoadScene("0");

        });
    }
    public void SetInfo(string info)
    {
        info_text.text = info;
    }
    public bool SetGold(int value)
    {
        if ((this.gold+value)>=0)
        {
            gold += value;
            gold_Text.text = "金币："+gold.ToString();
            return true;
        }
        else
        {
            hintInfo.gameObject.SetActive(true);
            return false;
        }
    }

    public void Stop()
    {
        if (Time.timeScale==0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene("1");// �ؿ�3 ��ť
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            stopWindow.gameObject.SetActive(!stopWindow.gameObject.activeSelf);
        }
    }

    public void AddTower(Tower tower)
    {
        towers.Add(tower);
    }
    public void RemoveTower(Tower tower)
    {
        towers.Remove(tower);
    }
    public void SetDestroyTower()
    {
        destroyNumber++;
        if (destroyNumber>5)
        {
            foreach (var item in towers)
            {
                if (item!=null)
                {
                    item.bullet.attack -= (int)(item.bullet.attack * 0.25f);
                }
            }
        }
    }
}
