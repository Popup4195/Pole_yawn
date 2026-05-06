using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerWindow : MonoBehaviour
{
    Button returnButton;
    public SelectWindow selectWindow;
    // Start is called before the first frame update
    void Start()
    {
        returnButton=transform.Find("returnButton").GetComponent<Button>();

        returnButton.onClick.AddListener(() =>
        {
            selectWindow.gameObject.SetActive(true);
            gameObject.SetActive(false);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
