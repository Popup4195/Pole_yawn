using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 升级防御塔UI
/// </summary>
public class UpLevelWindow : MonoBehaviour
{
    Grid geZi;
    Text info;
    float price;
    Transform ta;
    public static UpLevelWindow Instance;

    private Image icon;
    private Button button;
    private Button destroyButton;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        ta = transform.Find("Root/Ta");
        info = transform.Find("Root/Ta/info").GetComponent<Text>();
        icon = transform.Find("Root/Ta/icon").GetComponent<Image>();
        destroyButton = transform.Find("Root/destroyButton").GetComponent<Button>();
        button =icon.GetComponent<Button>();
        button.onClick.AddListener(CreateUpLevelTa);
        destroyButton.onClick.AddListener(() =>
        {
            Tower ta = geZi.baseObject as Tower;
            CombatInfoWindow.Instance.SetGold(ta.price / 2);
            GameObject.Destroy(ta.gameObject);
        });

    }
    public void CreateUpLevelTa()
    {
        if (CombatInfoWindow.Instance.SetGold(-(int)price))  //金币足够
        {
            Tower ta = geZi.baseObject as Tower;
            Tower prefab = Resources.Load<Tower>("Prefab/ta" + (ta.id + 1));  //创建对应的防御塔
            Tower tago = GameObject.Instantiate(prefab, ta.transform.position, ta.transform.rotation);
            GameObject.Destroy(ta.gameObject);
            geZi.baseObject = tago;

            if (tago.baseObjectType == BaseObjectType.DefenseTower)
            {
                CombatInfoWindow.Instance.AddTower(tago);
            }
        }
        transform.gameObject.SetActive(false);
    }
    public void ShowUpLevel(Grid geZi)  //显示要升级成的 防御塔UI 显示需要多少金币
    {
        Tower ta = geZi.baseObject as Tower;
            transform.gameObject.SetActive(true);
            transform.position = ta.transform.position;
        this.geZi = geZi;
        if (ta.level==2)  //3级防御塔是满级  满级了 就不显示升级按钮了
        {
            this.ta.gameObject.SetActive(false);
        }
        else
        {
            this.ta.gameObject.SetActive(true);

            price = ta.price+2;
            info.text = price + "金币";

            string path = "Sprite/" + (ta.id + 1);
            var sprite = Resources.Load<Sprite>(path);
            icon.sprite = sprite;

        }
    }
}
