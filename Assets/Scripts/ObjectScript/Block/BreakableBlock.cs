using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableBlock : MonoBehaviour
{
    [SerializeField] private GameObject[] cracks; //0~2 �ε����� Crack1, Crack2, Crack3

    private bool isBreaking = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //�ѹ��� ����ǵ��� �÷��� üũ
        if (!isBreaking)
        {
            isBreaking = true;
            //Update���� �ƴѰ����� �ݺ����� StartCoroutine ���� �ȴ���
            StartCoroutine(BreakSequence());
        }
    }

    private IEnumerator BreakSequence()
    {
        //1�� �������� cracks �迭�� ��Ҹ� ������� Ȱ��ȭ
        for (int i = 0; i < cracks.Length; i++)
        {
            if (cracks[i] != null)
                cracks[i].SetActive(true);
            //1���� �ݺ�
            yield return new WaitForSeconds(1f);
        }

        //�� �� �� Ȱ��ȭ�� �� �� �� �� ���(�߰��� 1�ʸ� �� �ΰ� ������)
        //yield return new WaitForSeconds(1f);

        //��� ����
        Destroy(gameObject);
    }
}
