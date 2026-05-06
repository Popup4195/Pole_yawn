using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//格子 就是 可以放置防御塔的地方
public class Grid : MonoBehaviour
{
    public BaseObject baseObject;
    public void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject()) { return; }  //点击到UI 旧不处理


        
        if (baseObject != null&& (baseObject.baseObjectType==BaseObjectType.Tower|| baseObject.baseObjectType == BaseObjectType.DefenseTower))
        {      
            UpLevelWindow.Instance.ShowUpLevel(this);  //点击的防御塔 就显示升级UI 出现
        }
        else
        {
            TaWindow.Instance.ShowTaWindow(this);  //点击的 地方没有防御塔 就显示创建防御塔UI
        }
    }
}
