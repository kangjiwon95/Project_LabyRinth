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
    private Image fadeImg;    // ���̵� �ƿ� �̹���
    private CanvasGroup fadeCanGroup;
    [SerializeField]
    private Text loadingText;    // �ε� % ǥ��
    [SerializeField]
    private GameObject loadingBar;   // �� �ð�

    private float fadeDuration = 1.5f; // ���̵� ȿ�� ���� �ð�


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

    public IEnumerator FadeOut(string SceneName)   // ���̵� �ƿ� ȿ��
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
            // �� �ε� �ڷ�ƾ ����
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

    private IEnumerator SceneLoad(string sceneName)   // �� �ε� �ڷ�ƾ
    {
        loadingBar.SetActive(true);
        fadeCanGroup.blocksRaycasts = true;

        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        async.allowSceneActivation = false; //�ۼ�Ʈ �����̿�

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
                    async.allowSceneActivation = true; //�� ��ȯ �غ� �Ϸ�
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
            loadingText.text = percentage.ToString("0") + "%"; //�ε� �ۼ�Ʈ ǥ��
        }
    }
}
