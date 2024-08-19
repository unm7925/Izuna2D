using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    protected Camera mainCamera;
    protected GameObject playerPos;
    protected bool isRotate; // üũ�ϸ� ������Ʈ�� ���ۺ��� ���ư��ϴ�

    public int damage;
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player");
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isRotate)
            transform.Rotate(Vector3.forward * 10);
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);
        // �þ� ������ ����� ����
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    Destroy(gameObject);
        
    //}
}