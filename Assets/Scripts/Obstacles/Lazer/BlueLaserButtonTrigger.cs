using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueLaserButtonTrigger : MonoBehaviour
{
    public BlueLaser[] blueLasers;
    private Animator animator;
    private bool isTrigger = false;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //�Ķ��� ������ ����
        if (other.CompareTag("BluePlayer"))    
        {
            isTrigger = !isTrigger;
            animator.SetBool("isTrigger", isTrigger);//����ġ �ִϸ��̼� �۵�
            for (int i = 0; i < blueLasers.Length; i++)
            {
                blueLasers[i].ToggleBlueLaser();//�Ķ��� ������ ����
            }
        }
    }
}
