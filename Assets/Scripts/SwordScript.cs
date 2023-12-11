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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameManager.LosePointTo(CharacterType.Enemy);
            Debug.Log("Contact: Enemy");

        } 
    }

    private void OnCollisionEnter(Collision other)
    {
    }
}
