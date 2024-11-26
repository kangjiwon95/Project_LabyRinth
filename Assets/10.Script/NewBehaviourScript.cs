using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpmanager : MonoBehaviour
{
    public static PopUpmanager Instance;

    // 스택을 사용해 활성화된 패널을 관리
    private Stack<GameObject> activePanels = new Stack<GameObject>();

    private void Awake()
    {
        if(Instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    #region Panel Managemaent
    public void OpenPanel(GameObject panel)
    {
        // 패널이 활성화되지 않은 경우에만 스택에 추가
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
            activePanels.Push(panel); // 활성화된 패널을 스택에 추가
        }
    }

    public void ClosePanel(GameObject panel)
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            activePanels.Pop(); // 스택에서 해당 패널을 제거
        }
    }

    public void CloseLastOpenedPanel()
    {
        if (activePanels.Count > 0)
        {
            GameObject lastPanel = activePanels.Peek();
            ClosePanel(lastPanel);
        }
    }
    #endregion
}
