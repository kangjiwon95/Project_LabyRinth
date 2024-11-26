using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpmanager : MonoBehaviour
{
    public static PopUpmanager Instance;

    // ������ ����� Ȱ��ȭ�� �г��� ����
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
        // �г��� Ȱ��ȭ���� ���� ��쿡�� ���ÿ� �߰�
        if (!panel.activeSelf)
        {
            panel.SetActive(true);
            activePanels.Push(panel); // Ȱ��ȭ�� �г��� ���ÿ� �߰�
        }
    }

    public void ClosePanel(GameObject panel)
    {
        if (panel.activeSelf)
        {
            panel.SetActive(false);
            activePanels.Pop(); // ���ÿ��� �ش� �г��� ����
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
