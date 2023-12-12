using System;
using Models;
using UnityEngine;

public class GameStageController : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject enemyObject;
    public float offset = 2.0f;

    private GameManager gameManager;
    private void Start()
    {
        gameManager = GameManager.GetInstance();
    }


    public void InitStage()
    {
        var stageMid = transform.position;
        playerObject.transform.position = stageMid - (transform.forward * offset);
        enemyObject.transform.position = stageMid + (transform.forward * offset);

        
        foreach (Transform t in playerObject.transform)
        {
            if (t.CompareTag("XR Camera Offset")) t.localPosition = new Vector3(0f, t.localPosition.y, 0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
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