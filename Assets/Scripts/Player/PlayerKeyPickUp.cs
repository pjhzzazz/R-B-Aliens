using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class PlayerKeyPickUp : MonoBehaviour
{
    [Header("�ݱ�/������ Ű")]
    [SerializeField] KeyCode pickKey = KeyCode.E;

    [Tooltip("Ű�� ���� �� �ڽ� ������Ʈ")]
    [SerializeField] Transform holdPoint;

    PickupableKey heldKey = null;

    bool isInArea = false;

    public static bool isHeld = false;

    void Update()
    {
        if (Input.GetKeyDown(pickKey) && isInArea)
        {
            if (!isHeld)
            {
                TryPickUp();
            }
            else if (isHeld)
            {
                DropKey();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            isInArea = true;
            heldKey = collision.GetComponent<PickupableKey>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            isInArea = false;
            if (heldKey != null && heldKey.gameObject == collision.gameObject)
            {
                heldKey = null;
            }
        }
    }

    void TryPickUp()
    {
        if (heldKey != null)
        {
            heldKey.PickUp(holdPoint);
            return;
        }
    }

    void DropKey()
    {
        if (heldKey != null)
        {
            heldKey.Drop();
            return;
        }
    }
}
