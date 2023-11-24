using System;
using System.Collections;
using Models;
using TMPro;
using UnityEngine;

public class HudUiController : MonoBehaviour
{
        public TMP_Text remainTimeText;
        public TMP_Text playerPointText;
        public TMP_Text enemyPointText;
        public TMP_Text centerTimerText;
        public TMP_Text gameResultText;
        
        private GameManager gameManager;
        
        private void Start()
        {
            gameManager = GameManager.GetInstance();
        }


        private void Update()
        {
            
        }

        private void LateUpdate()
        {
            remainTimeText.text = $"{gameManager.GetRemainTime():F4}";
            playerPointText.text = $"{gameManager.playerPoints}";
            enemyPointText.text = $"{gameManager.enemyPoints}";
            gameResultText.text = GetGameResultString();
        }

        private string GetGameResultString()
        {
            switch (gameManager.result)
            {
                case GameResult.None:
                    gameResultText.gameObject.SetActive(false);
                    break;
                case GameResult.PlayerWin:
                    gameResultText.gameObject.SetActive(true);
                    return "Win !!";
                case GameResult.PlayerLose:
                    gameResultText.gameObject.SetActive(true);
                    return "Lose..TT";
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return null;
        }

        public void StartCounter(int timerSeconds = 3)
        {
            StartCoroutine(CountCenterTimer(timerSeconds));
        }

        private IEnumerator CountCenterTimer(int timerSeconds)
        {
            if (timerSeconds == 0)
            {
                centerTimerText.gameObject.SetActive(false);
                gameManager.StartGame();
                yield break;
            }
            centerTimerText.gameObject.SetActive(true);
            centerTimerText.text = $"{timerSeconds}"; 
            yield return new WaitForSeconds(1);
            StartCoroutine(CountCenterTimer(timerSeconds-1));
        }
}