using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyCircle : MonoBehaviour
{
    public float speed = 5f; // �������� �������� ����������
    private bool movingRight = true; // ���� ��� ����������� ����������� ��������

    void Update()
    {
        // �������� ������
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    // ��������� ������������
    void OnCollisionEnter2D(Collision2D collision)
    {
        // ���� ������������ ��������� � ���-��, ����� ������� ���������� (��� ����-�� �������, ��� ������ ���������� ��������), �������� �����������
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            movingRight = !movingRight;
        }
    }
}