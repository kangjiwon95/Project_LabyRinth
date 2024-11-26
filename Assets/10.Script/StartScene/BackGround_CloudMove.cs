using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_CloudMove : MonoBehaviour
{
    // 구름 움직임
    [Header("Cloud_Move")]
    [SerializeField]
    private MeshRenderer cloud_Front; // 구름 앞부분
    [SerializeField]
    private MeshRenderer cloud_Mid; // 구름 중간

    // 오른쪽 움직임
    private float rightOffset;
    // 왼쪽 움직임
    private float leftOffset;
    // 움직임 속도
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

    #region Cloud Move(구름 움직임)
    private void Cloud_Front_Move()    // 구름 앞 움직임
    {
        rightOffset += Time.deltaTime * speed;

        cloud_Front.material.mainTextureOffset = new Vector2 (rightOffset, 0);
    }

    private void Cloud_Mid_Move()    // 구름 중간 움직임
    {
        leftOffset -= Time.deltaTime * speed;

        cloud_Mid.material.mainTextureOffset = new Vector2(leftOffset, 0);
    }
    #endregion
}
