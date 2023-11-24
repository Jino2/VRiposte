using System;
using Models;
using UnityEngine;

public class GameStageController : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject enemyObject;
    public static float offsetF => 0.5f;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.GetInstance();
    }

    public void InitStage()
    {
        var stageMid = transform.position;
        playerObject.transform.position = stageMid - (transform.forward* 1.0f);
        enemyObject.transform.position = stageMid + (transform.forward* 1.0f);
    }


    private void OnCollisionExit(Collision other)
    {
        Debug.Log($"{other.gameObject.tag} is out");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"{other.gameObject.tag} is out - trigger");

        if (other.CompareTag("Player"))
        {
            gameManager.LosePointTo(CharacterType.Player);
        }
        else if (other.CompareTag("Enemy"))
        {
            gameManager.LosePointTo(CharacterType.Enemy);
        }
    }
}