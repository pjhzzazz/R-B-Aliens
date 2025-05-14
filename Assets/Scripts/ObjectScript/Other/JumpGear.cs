using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpGear : MonoBehaviour
{
    public float jumpForce = 15f; // ���� �� ����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;

        // RedPlayer �Ǵ� BluePlayer �±��� ���� �۵�
        if (tag != "RedPlayer" && tag != "BluePlayer") return;

        // Rigidbody2D ��������
        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Y�� �ӵ� �ʱ�ȭ �� ���� �� ���ϱ�
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            Debug.Log($"JumpGear �۵�: {tag} ���� ����!");
        }
    }
}