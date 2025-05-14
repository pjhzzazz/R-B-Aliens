using System.Collections;
using System.Collections.Generic;
// GoalDoor.cs
using UnityEngine;

public class GoalDoor : MonoBehaviour
{
    [SerializeField] private Collider2D GoalCollider;

    //��������Ʈ
    [SerializeField] private GameObject DoorTop;
    [SerializeField] private GameObject DoorBot;
    //�� ���� �÷��̾� � ���� �������ִ��� Ȯ���ϴ� ǥ�� ������Ʈ
    [SerializeField] private GameObject GoalRed;
    [SerializeField] private GameObject GoalBlue;
    //�� ������ �÷��̾� ��Ȱ��ȭ�� ���� ������Ʈ - �÷��̾� �������
    [SerializeField] private GameObject PlayerRed;
    [SerializeField] private GameObject PlayerBlue;


    //Ű ȹ�� ����
    private bool hasRedKey = false;
    private bool hasBlueKey = false;

    //�� ������ �÷��̾� ���� ����
    private bool IsRedGoal = false;
    private bool IsBlueGoal = false;

    private void Start()
    {
        GoalCollider.enabled = false;
    }

    //���� ��ũ��Ʈ���� ȣ���� �޼����
    public void CollectRedKey()
    {
        hasRedKey = true;
        CheckBothKeys();
    }

    public void CollectBlueKey()
    {
        hasBlueKey = true;
        CheckBothKeys();
    }

    // ���� ����, �Ķ� ���� �Ѵ� �ֿ����� �˻�
    private void CheckBothKeys()
    {
        if (hasRedKey && hasBlueKey)
            OpenGoalDoor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BluePlayer"))
        {
            IsBlueGoal = true;
            //�Ķ� �÷��̾� �������
            PlayerBlue.SetActive(false);
            GoalBlue.SetActive(true);
        }
        if (collision.gameObject.CompareTag("RedPlayer"))
        {
            IsRedGoal = true;
            //���� �÷��̾� �������
            PlayerRed.SetActive(false);
            GoalRed.SetActive(true);
        }
    }

    private void OpenGoalDoor()
    {
        DoorTop.SetActive(false);
        DoorBot.SetActive(false);
        GoalCollider.enabled = true;
        Debug.Log("�������� �� ����!");
        if (IsBlueGoal)
        {
            GoalBlue.SetActive(true);
        }
        if (IsRedGoal)
        {
            GoalRed.SetActive(true);
        }
        if (IsBlueGoal || IsRedGoal)
        {
            GameManager.Instance.GameClear();
        }
    }
}
