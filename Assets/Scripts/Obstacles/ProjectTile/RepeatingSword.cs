using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingSword : MonoBehaviour
{
    public float speed = 8.0f;
    public Vector2 direction = Vector2.right;
    void Start()
    {

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //x, y ���� ���������� ������ �������� ���
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);//Z���� �������� angle��ŭ ȸ���� ȸ������ ��ȯ Į�� �������־ -90
    }


    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); //������ ��������, �ʴ� speed��ŭ, ���� �������� �̵�

        if (transform.position.x < 15f)  
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer"))
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
