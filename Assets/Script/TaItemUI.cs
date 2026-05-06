using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaItemUI : MonoBehaviour
{
    public int price;
    public int id;
    Button button;
    Text text;
    public void Awake()
    {
        button = GetComponent<Button>();
        text=transform.Find("info").GetComponent<Text>();
        button.onClick.AddListener(Create);
    }
    private void Create() //点击对应的防御塔UI  就生成对应的防御塔在格子里面
    {

        if (CombatInfoWindow.Instance.SetGold(-price))
        {
            Grid geZi = TaWindow.Instance.cutGeZi;
            Tower prefab = Resources.Load<Tower>("Prefab/ta" + id);
            Tower go=GameObject.Instantiate(prefab);

            go.transform.position = geZi.transform.position;
            go.gameObject.SetActive(true);

            geZi.baseObject = go;

            if (go.baseObjectType==BaseObjectType.DefenseTower)
            {
                CombatInfoWindow.Instance.AddTower(go);
            }
        }
        TaWindow.Instance.gameObject.SetActive(false);

    }
}
