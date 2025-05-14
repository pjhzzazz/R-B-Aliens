using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        int layer = gameObject.layer;

        // Case 1: ���� DeadZone
        if (layer == LayerMask.NameToLayer("DeadZone"))
        {
            if (tag == "RedPlayer" || tag == "BluePlayer")
            {
                HandleDeath(collision);
            }
        }
        // Case 2: RedDeadZone�� RedPlayer��
        else if (layer == LayerMask.NameToLayer("RedDeadZone"))
        {
            if (tag == "RedPlayer")
            {
                HandleDeath(collision);
            }
        }
        // Case 3: BlueDeadZone�� BluePlayer��
        else if (layer == LayerMask.NameToLayer("BlueDeadZone"))
        {
            if (tag == "BluePlayer")
            {
                HandleDeath(collision);
            }
        }
    }

    private void HandleDeath(Collider2D collision)
    {
        Debug.Log($"{collision.tag} �� {LayerMask.LayerToName(gameObject.layer)}�� �浹�߽��ϴ�.");

        // ĳ���� ��� �޼���
        GameManager.Instance.GameOver();

    }
}
