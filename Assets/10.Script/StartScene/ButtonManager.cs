using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [Header("Button")]
    [SerializeField]
    private Button gameStartButton;    // ���� ���� ��ư
    [SerializeField]
    private Button settingButton;    // ���� ���� ��ư
    [SerializeField]
    private Button gameQuitButton;    // ���� ���� ��ư

    [Header("GameQuit Button")]
    [SerializeField]
    private Button gameQuit_Yes_Button;
    [SerializeField]
    private Button gameQuit_No_Button;
    [SerializeField]
    private Button gameQuit_UI_offButton;

    [Header("UI Object")]
    [SerializeField]
    private GameObject settingObj;    // ���� UI ������Ʈ
    [SerializeField]
    private GameObject quitObj;    // ���� ���� UI ������Ʈ

    void Start()
    {
        // ���� ���� ��ư
        gameStartButton.onClick.AddListener(() => GameStartButton());
        // ���� ���� ��ư
        settingButton.onClick.AddListener(() => SettingButton());
        // ���� ���� ��ư
        gameQuitButton.onClick.AddListener(() => GameQuitButton());

        // ���� ���� Yes ��ư
        gameQuit_Yes_Button.onClick.AddListener(() => GameQuit_Yes_Button());
        gameQuit_No_Button.onClick.AddListener(() => GameQuit_No_Button());
        gameQuit_UI_offButton.onClick.AddListener(() => GameQuit_No_Button());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            PopUpmanager.Instance.CloseLastOpenedPanel();
        }
    }

    #region Button
    private void GameStartButton()    // ���� ����
    {
        
    }

    private void SettingButton()    // ���� ����
    {

    }

    private void GameQuitButton()    // ���� ����
    {
        PopUpmanager.Instance.OpenPanel(quitObj);
    }

    #region GameQuit UI Button(���� ���� UIâ ��ư)
    private void GameQuit_Yes_Button()     // ���� ���� UI Yes ��ư
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit(); // ���ø����̼� ����
    }
    private void GameQuit_No_Button()      // ���� ���� UI No ��ư
    {
        PopUpmanager.Instance.ClosePanel(quitObj);
    }
    #endregion
    #endregion
}
