using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainWindow : MonoBehaviour
{
    Button start;
    Button exit;
    Button setting;

    public SettingWindow settingWindow;
    public SelectWindow selectWindow;
    void Start()
    {
        start = transform.Find("Start").GetComponent<Button>();
        exit = transform.Find("Exit").GetComponent<Button>();
        setting = transform.Find("Setting").GetComponent<Button>();

        start.onClick.AddListener(() =>
        {
            selectWindow.gameObject.SetActive(true);
        });
        exit.onClick.AddListener(() =>
        {
            //预处理
#if UNITY_EDITOR  //在编辑器模式下

            UnityEditor.EditorApplication.isPlaying = false;
#else
                            Application.Quit();
#endif

        });
        setting.onClick.AddListener(() =>
        {
            settingWindow.gameObject.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
