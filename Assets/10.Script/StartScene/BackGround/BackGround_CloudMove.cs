using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_CloudMove : MonoBehaviour
{
    // ���� ������
    [Header("Cloud_Move")]
    [SerializeField]
    private MeshRenderer cloud_Front; // ���� �պκ�
    [SerializeField]
    private MeshRenderer cloud_Mid; // ���� �߰�

    // ������ ������
    private float rightOffset;
    // ���� ������
    private float leftOffset;
    // ������ �ӵ�
    private float speed;


    void Start()
    {
        rightOffset = 0.1f;
        leftOffset = 0.1f;
        speed = 0.01f;
    }

    void Update()
    {
        Cloud_Front_Move(); 

        Cloud_Mid_Move();
    }

    #region Cloud Move(���� ������)
    private void Cloud_Front_Move()    // ���� �� ������
    {
        rightOffset += Time.deltaTime * speed;

        cloud_Front.material.mainTextureOffset = new Vector2 (rightOffset, 0);
    }

    private void Cloud_Mid_Move()    // ���� �߰� ������
    {
        leftOffset -= Time.deltaTime * speed;

        cloud_Mid.material.mainTextureOffset = new Vector2(leftOffset, 0);
    }
    #endregion
}
