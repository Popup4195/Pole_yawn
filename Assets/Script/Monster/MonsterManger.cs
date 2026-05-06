using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MonsterManger : MonoBehaviour
{
    public BaseObject baseObject;
    public static MonsterManger Instance;
    public Text info;
    public int WaveNumber;
    public float MonsterNumber;
    public float time=2;
    public BaseObject target;

    bool isStart;
    private float startTime;// 1 7 1 7 0 3 0 2 1 7 1 7
    public float cutMonsterNumber;
     List<Monster> monsters=new List<Monster>();

    public List<Monster> cutMonstr = new List<Monster>();
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        isStart = true;
        startTime = time;
        cutMonsterNumber = MonsterNumber;
        for (int i = 0; i < transform.childCount; i++)  // 1 7 1 7 0 0 1 7 1 7 0 2 0 8 1 7 1 7 1 7 0 2 0 1 1 7 1 7 1 7 1 7 ҄1 7
        {
            Monster monster = transform.GetChild(i).GetComponent<Monster>();
            monster.Init(target);
            monsters.Add(monster);
        }
        info.text = "第"+"1"+"波";
    }

    // Update is called once per frame
    void Update()
    {
        CreationMonster();
    }
    public void CreationMonster() // 1 7 1 7 1 7 1 7 1 7 1 7 1 7 1 7
    {
        if (!isStart) { return; }
        if (WaveNumber==0)  // 1 7 1 7 1 7 0 6 1 7 1 7   1 7 1 7 1 7 1 70 1 7 1 7  1 7 0 9 1 3 1 7 1 7 1 7 1 7 1 7 1 7 1 7
        {
            //SceneManager.LoadScene("main");
            SettlementWindow.Instance.ShengLi();
            return;
        }
        if (cutMonsterNumber > 0) // 1 7 1 7 0 2 1 7 1 7 1 7 1 7 1 7 1 7 1 7 1 7  1 7 1 7 1 7 1 70 1 7 0 0 1 7 1 7 1 7 1 7 1 7 1 7 0 6 1 7 1 7 1 7
        {
            if ((time -= Time.deltaTime) <= 0)
            {
                time = startTime;
                cutMonsterNumber--;
                Monster prefab = monsters[Random.Range(0, monsters.Count)];
                Monster monster=GameObject.Instantiate(prefab);
                monster.transform.position = this.transform.position;
                monster.Init(target);
                monster.gameObject.SetActive(true);
                cutMonstr.Add(monster);
            }
        }
        else 
        {
            isStart = false;
            StartCoroutine(enumerator());
        }
    }

    private IEnumerator enumerator()  //10 1 7 1 7 1 7  0 6 1 7 1 7 1 7 1 7 0 5 1 7 1 7 1 7 1 7 1 7 1 7
    {
        yield return new WaitForSeconds(10);
        isStart = true;
        WaveNumber--;
        cutMonsterNumber = MonsterNumber;
        foreach (Monster monster in monsters)
        {
            monster.maxHp *= 1.8f;
        }
        if (info)
        {
            info.text = "还剩" + (WaveNumber-1).ToString()+"波";
        }
    }
}
