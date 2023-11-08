using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    private bool hit = false;
    
    public static GameManager GetInstance()
    {
        if (instance != null) return instance;

        instance = new GameManager();
        return instance;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else if(instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HitTarget()
    {
        this.hit = true;
    }
}
