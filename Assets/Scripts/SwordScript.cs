using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

public class SwordDetectionScript : MonoBehaviour
{
    public GameObject owner;
    
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.Hit(CharacterType.Enemy);
        }
    }
}
