using System;
using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;

public class E_SwordScript : MonoBehaviour
{
    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameManager = GameManager.GetInstance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.LosePointTo(CharacterType.Player);
            Debug.Log("Contact: Player");

        }
        
    }
}
