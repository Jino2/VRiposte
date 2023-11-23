using System;
using TMPro;
using UnityEngine;

public class HudUiController : MonoBehaviour
{
        public TMP_Text remainTimeText;
        public TMP_Text playerPointText;
        public TMP_Text enemyPointText;
        
        private GameManager gameManager;
        
        private void Start()
        {
            gameManager = GameManager.GetInstance();
        }

        private void Update()
        {
            remainTimeText.text = $"{gameManager.GetRemainTime():F4}";
            playerPointText.text = $"{gameManager.playerPoints}";
            enemyPointText.text = $"{gameManager.enemyPoints}";
        }
}