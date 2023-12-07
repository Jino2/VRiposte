using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

public class E_SwordScript : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.LosePointTo(CharacterType.Player);
            Debug.Log("Contact: Player");

        }
    }
}
