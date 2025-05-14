using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedLaserButtonTrigger : MonoBehaviour
{
    public RedLaser[] redLasers;
    private Animator animator;
    private bool isTrigger = false;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedPlayer"))  
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger); // ����ġ �ִϸ��̼� �۵�
            for (int i = 0; i < redLasers.Length; i++)
            {
                redLasers[i].ToggleRedLaser();     //������ ������ ����
            }
        }
    }
}

