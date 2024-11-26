using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;

    [Header("Loding")]
    [SerializeField]
    private Image fadeImg;    // 페이드 아웃 이미지
    private CanvasGroup fadeCanGroup;
    [SerializeField]
    private Text loadingText;    // 로딩 % 표시
    [SerializeField]
    private GameObject loadingBar;   // 모래 시계

    private float fadeDuration = 1.5f; // 페이드 효과 지속 시간


    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        fadeCanGroup = fadeImg.GetComponent<CanvasGroup>();
    }

    public IEnumerator FadeOut(string SceneName)   // 페이드 아웃 효과
    {
        Color color = fadeImg.color;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(0 + (elapsedTime / fadeDuration));
            fadeImg.color = color;
            yield return null;
        }

        if (loadingBar != null)
        {
            // 씬 로드 코루틴 실행
            StartCoroutine(SceneLoad(SceneName));
        }
    }

    private IEnumerator FadeIn()
    {
        Color color = fadeImg.color;
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(1 - (elapsedTime / fadeDuration));
            fadeImg.color = color;
            yield return null;
        }

        color.a = 0;
        fadeImg.color = color;
    }

    private IEnumerator SceneLoad(string sceneName)   // 씬 로드 코루틴
    {
        loadingBar.SetActive(true);
        fadeCanGroup.blocksRaycasts = true;

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; //퍼센트 딜레이용

        float past_time = 0;
        float percentage = 0;

        while (!(async.isDone))
        {
            yield return null;

            past_time += Time.deltaTime;

            if (percentage >= 90)
            {
                percentage = Mathf.Lerp(percentage, 100, past_time);

                if (percentage == 100)
                {
                    async.allowSceneActivation = true; //씬 전환 준비 완료
                    loadingBar.SetActive(false);
                    fadeCanGroup.blocksRaycasts = false;
                    StartCoroutine(FadeIn());
                }
            }
            else
            {
                percentage = Mathf.Lerp(percentage, async.progress * 100f, past_time);
                if (percentage >= 90) past_time = 0;
            }
            loadingText.text = percentage.ToString("0") + "%"; //로딩 퍼센트 표기
        }
    }
}
