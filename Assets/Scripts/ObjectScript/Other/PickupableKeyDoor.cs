using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableKeyDoor : MonoBehaviour
{
    private GameObject spriteAndCollider;

    void Awake()
    {
        // "SpriteAndCollider" ��� �̸��� �ڽĸ� ã�Ƽ� ĳ��
        spriteAndCollider = transform.Find("lock_yellow")?.gameObject;
        if (spriteAndCollider == null)
            Debug.LogError("�ڽ� 'lock_yellow' �� ã�� �� �����ϴ�.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KeyTrigger") && spriteAndCollider != null && spriteAndCollider.activeSelf)
            spriteAndCollider.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("KeyTrigger") && spriteAndCollider != null && spriteAndCollider.activeSelf)
            spriteAndCollider.SetActive(true);
    }
}