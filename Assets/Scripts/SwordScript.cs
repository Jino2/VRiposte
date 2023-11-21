using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDetectionScript : MonoBehaviour
{
    public GameObject owner;
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"{other.gameObject.name} collide!");
        if (other.gameObject.CompareTag("Enemy"))
        {
            // GameManager.GetInstance();
        }
    }
}
