using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWindow : MonoBehaviour
{
    Button map;
    Button tower;
    Button Tab;

    public MapWindow mapWindow;
    public Transform towerInfo;
    public Transform tabInfo;
    void Start()
    {
        map = transform.Find("Scroll View/Viewport/Content/map").GetComponent<Button>();
        tower = transform.Find("Scroll View/Viewport/Content/Tower").GetComponent<Button>();
        Tab = transform.Find("Scroll View/Viewport/Content/monster").GetComponent<Button>();

        map.onClick.AddListener(() =>
        {
            mapWindow.gameObject.SetActive(true);
        });
        tower.onClick.AddListener(() =>
        {
            towerInfo.gameObject.SetActive(true);
        });
        Tab.onClick.AddListener(() =>
        {
         //   tabInfo.gameObject.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
