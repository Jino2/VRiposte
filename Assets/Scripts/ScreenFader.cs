using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage; // UI Image를 사용하여 화면을 가리는 역할을 할 것입니다.
    public float fadeInSpeed = 1.0f; // 페이드 속도를 조절할 변수
    public float fadeOutSpeed = 10.0f;
    
    private GameManager gm;
    private bool fading = false;
    private bool faded = false;
    private void Start()
    {
        gm = GameManager.GetInstance();
    }


    private void Update()
    {
        if(gm.isGamePaused && !faded) StartFadeOut();
        if (!gm.isGamePaused) faded = false;
    }

    private void StartFadeOut()
    {
        if (fading) return;
        fading = true;
        faded = true;
        fadeImage.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        while (fadeImage.color.a < 1) // 알파값이 1보다 작은 동안 반복
        {
            Color newColor = fadeImage.color;
            newColor.a += Time.deltaTime * fadeOutSpeed;
            fadeImage.color = newColor;
            yield return null;
        }

        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        while (fadeImage.color.a > 0) // 알파값이 0보다 큰 동안 반복
        {
            Color newColor = fadeImage.color;
            newColor.a -= Time.deltaTime * fadeInSpeed;
            fadeImage.color = newColor;
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);
        fading = false;
    }
}