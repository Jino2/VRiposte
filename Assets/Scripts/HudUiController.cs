using System;
using TMPro;
using UnityEngine;

public class HudUiController : MonoBehaviour
{
        public TMP_Text remainTimeText;

        private GameManager gameManager;
        
        private void Start()
        {
            gameManager = GameManager.GetInstance();
        }

        private void Update()
        {
            remainTimeText.text = $"{gameManager.GetRemainTime():F4}";
        }
}