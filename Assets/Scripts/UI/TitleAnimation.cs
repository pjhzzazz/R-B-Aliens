using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnimation : MonoBehaviour
{
        Animator animator;

        void OnEnable()
        {
             animator = GetComponent<Animator>();
             animator.Play("Title", 0, 0f);  // �ٽ� ���
        }
}
