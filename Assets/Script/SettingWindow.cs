using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingWindow : MonoBehaviour
{
    Slider sliderbg;
    Slider sliderattack;
    // Start is called before the first frame update
    void Start()
    {
        sliderbg = transform.Find("Sliderbg").GetComponent<Slider>();
        sliderattack=transform.Find("Sliderattack").GetComponent<Slider>();
        sliderbg.onValueChanged.AddListener((value) =>
        {
            Config.Instance.BgSound = value;

        });
        sliderattack.onValueChanged.AddListener((value) =>
        {
            Config.Instance.attackSound = value;

        });
    }

}
