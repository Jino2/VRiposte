using System;
using Models;
using UnityEngine;

public class GameStageController : MonoBehaviour
{
    public GameObject playerObject;
    public GameObject enemyObject;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.GetInstance();
    }


    public void InitStage()
    {
        var stageMid = transform.position;
        playerObject.transform.position = stageMid - (transform.forward * 1.0f);
        enemyObject.transform.position = stageMid + (transform.forward * 1.0f);

        foreach (Transform t in playerObject.transform)
        {
            if (t.CompareTag("XR Camera Offset")) t.localPosition = new Vector3(0f, 1.36144f, 0f);
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