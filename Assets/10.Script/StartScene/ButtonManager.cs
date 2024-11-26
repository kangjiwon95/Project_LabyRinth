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

    [Header("Setting UI Button")]
    [SerializeField]
    private Button setting_UI_Off_Button;

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

        // ���� ���� UI ��ư
        setting_UI_Off_Button.onClick.AddListener(() => Setting_UiOff_Button());

        // ���� ���� Yes ��ư
        gameQuit_Yes_Button.onClick.AddListener(() => GameQuit_Yes_Button());
        gameQuit_No_Button.onClick.AddListener(() => GameQuit_No_Button());
        gameQuit_UI_offButton.onClick.AddListener(() => GameQuit_No_Button());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            UiPanelManager.Instance.CloseLastOpenedPanel();
        }
    }

    #region Button
    private void GameStartButton()    // ���� ����
    {
        
    }

    #region GameSetting UI Button(���� ���� UI ��ư)
    private void SettingButton()    // ���� ����
    {
        UiPanelManager.Instance.OpenPanel(settingObj);
    }

    private void Setting_UiOff_Button()
    {
        UiPanelManager.Instance.ClosePanel(settingObj);
    }
    #endregion

    #region GameQuit UI Button(���� ���� UI ��ư)
    private void GameQuitButton()    // ���� ����
    {
        UiPanelManager.Instance.OpenPanel(quitObj);
    }
    private void GameQuit_Yes_Button()     // ���� ���� UI Yes ��ư
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit(); // ���ø����̼� ����
    }
    private void GameQuit_No_Button()      // ���� ���� UI No ��ư
    {
        UiPanelManager.Instance.ClosePanel(quitObj);
    }
    #endregion
    #endregion
}
