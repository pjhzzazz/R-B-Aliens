using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangShield : MonoBehaviour
{

    public float distance = 3f;           // �̵� �Ÿ�
    public float speed = 2f;              // �̵� �ӵ�
    public float spinSpeed = 600f;        // ȸ�� �ӵ� (��/��)

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool go = true;
    private bool back = false;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + transform.right * distance;
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);


        if (go)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPos) < 0.01f) // Ÿ�� ��ġ�� ������
            {
                go = false;
                back = true;
            }
        }
        else if (back)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
            if(Vector3.Distance(transform.position, startPos) < 0.01f) // ó�� ��ġ�� ������
            {
                go = true;
                back = false;
            }
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("RedPlayer") || collision.gameObject.CompareTag("BluePlayer"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
