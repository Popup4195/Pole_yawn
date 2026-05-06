using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : BaseObject
{
    public Grid grid;
    public override void Start()
    {
        base.Start();
        grid=transform.parent.GetComponent<Grid>();
    }
    public override void Harm(float v)
    {
        base.Harm(v);
        if (hp <= 0 )
        {
            if (Random.Range(0, 1)==0)
            {
                CombatInfoWindow.Instance.SetGold(5);

            }
            else
            {
                CombatInfoWindow.Instance.SetGold(20);
            }
            Tower prefab = Resources.Load<Tower>("Prefab/ta" + 1);
            Tower go = GameObject.Instantiate(prefab);

            go.transform.position = grid.transform.position;
            go.gameObject.SetActive(true);

            grid.baseObject = go;
        }
    }
}
