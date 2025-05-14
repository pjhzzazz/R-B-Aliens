using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSword : MonoBehaviour
{
    public float lifeTime = 10.0f;
    public float speed = 8.0f;
    public Vector2 direction = Vector2.right;
    void Start()
    {
        Destroy(gameObject, lifeTime);

         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; //x, y ���� ���������� ������ �������� ���
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);//Z���� �������� angle��ŭ ȸ���� ȸ������ ��ȯ Į�� �������־ -90
    }


    void Update()
    {
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World); //������ ��������, �ʴ� speed��ŭ, ���� �������� �̵�
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer"))
        {
            GameManager.Instance.GameOver();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
