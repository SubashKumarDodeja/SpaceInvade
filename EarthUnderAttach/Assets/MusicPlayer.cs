﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);        
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("loadFirstScene",2f); 
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void loadFirstScene()
    {
        SceneManager.LoadScene("Level1");
    }
}
