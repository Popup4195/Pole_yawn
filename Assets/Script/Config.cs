using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config : MonoBehaviour
{
    private AudioSource audioSource;
    public static Config Instance { get; private set; }

    private float bgSound;

    public float BgSound { get { return bgSound; }
        set
        {
            bgSound = value;
            audioSource.volume = bgSound;
        } }
    public float attackSound;
    // Start is called before the first frame update
    void Start()
    {

        Instance= this;
        audioSource = GetComponent<AudioSource>();
        GameObject.DontDestroyOnLoad(this.gameObject);
        audioSource.volume = bgSound;
    }

}
