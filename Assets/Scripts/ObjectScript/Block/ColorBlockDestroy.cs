using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlockDestroy : MonoBehaviour
{
    // RedBlock ���̾�� BlueBlock ���̾��� ��ȣ�� Inspector���� ������ ���� ����
    public LayerMask redBlockLayer;
    public LayerMask blueBlockLayer;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string otherTag = collision.gameObject.tag;
        int thisLayer = gameObject.layer;

        // Case 1: RedPlayer�� RedBlock�� �浹
        if (otherTag == "RedPlayer" && thisLayer == LayerMask.NameToLayer("RedBlock"))
        {
            Debug.Log("RedPlayer�� RedBlock �浹! ������Ʈ �ı�");
            Destroy(gameObject);
        }
        // Case 2: BluePlayer�� BlueBlock�� �浹
        else if (otherTag == "BluePlayer" && thisLayer == LayerMask.NameToLayer("BlueBlock"))
        {
           Debug.Log("BluePlayer�� BlueBlock �浹! ������Ʈ �ı�");
            Destroy(gameObject);
        }
        // �� �� ������ �ƹ� �ϵ� ���� ���� �� �浹 ���� ����
        else
        {
            //Debug.Log("�ٸ� ���� - �浹 ���� (���� �� ����)");
        }
    }
}
