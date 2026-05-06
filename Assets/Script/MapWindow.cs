using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapWindow : MonoBehaviour
{
    public SelectWindow selectWindow;
    Button map1;
    Button map2;
    Button returnButton;
    // Start is called before the first frame update
    void Start()
    {
        map1 = transform.Find("Viewport/Content/map1").GetComponent<Button>();
        map2 = transform.Find("Viewport/Content/map2").GetComponent<Button>();
        returnButton = transform.Find("returnButton").GetComponent<Button>();
        returnButton.onClick.AddListener(() =>
        {
            selectWindow.gameObject.SetActive(true);
            gameObject.SetActive(false);
        });

        map1.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("1");// 关卡3 按钮

        });
        map2.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("2");// 关卡3 按钮

        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
