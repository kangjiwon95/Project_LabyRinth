using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSceneManager : MonoBehaviour
{
    [Header("Button")]
    [SerializeField]
    private Button gameStartButton;    // 게임 시작 버튼
    [SerializeField]
    private Button settingButton;    // 게임 셋팅 버튼
    [SerializeField]
    private Button gameQuitButton;    // 게임 종료 버튼

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
    private GameObject settingObj;    // 셋팅 UI 오브젝트
    [SerializeField]
    private GameObject quitObj;    // 게임 종료 UI 오브젝트

    void Start()
    {
        // 게임 시작 버튼
        gameStartButton.onClick.AddListener(() => GameStartButton());
        // 게임 셋팅 버튼
        settingButton.onClick.AddListener(() => SettingButton());
        // 게임 종료 버튼
        gameQuitButton.onClick.AddListener(() => GameQuitButton());

        // 게임 셋팅 UI 버튼
        setting_UI_Off_Button.onClick.AddListener(() => Setting_UiOff_Button());

        // 게임 종료 Yes 버튼
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
    private void GameStartButton()    // 게임 시작
    {
        
    }

    #region GameSetting UI Button(게임 셋팅 UI 버튼)
    private void SettingButton()    // 게임 셋팅
    {
        UiPanelManager.Instance.OpenPanel(settingObj);
    }

    private void Setting_UiOff_Button()
    {
        UiPanelManager.Instance.ClosePanel(settingObj);
    }
    #endregion

    #region GameQuit UI Button(게임 종료 UI 버튼)
    private void GameQuitButton()    // 게임 종료
    {
        UiPanelManager.Instance.OpenPanel(quitObj);
    }
    private void GameQuit_Yes_Button()     // 게임 종료 UI Yes 버튼
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit(); // 어플리케이션 종료
    }
    private void GameQuit_No_Button()      // 게임 종료 UI No 버튼
    {
        UiPanelManager.Instance.ClosePanel(quitObj);
    }
    #endregion
    #endregion
}
