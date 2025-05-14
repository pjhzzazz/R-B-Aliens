using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageController : MonoBehaviour
{
    public static StageController Instance {  get; private set; }

    [Header("ĳ���� ������")]
    public GameObject RedPlayerPrefab;
    public GameObject BluePlayerPrefab;

    [Header("�������� �߰�")]
    public GameObject[] stageParents;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else Destroy(gameObject);
    }

    public void ChangeStage(int selectedStage) // �������� ��ȯ
    {
        for (int i = 0; i < stageParents.Length; i++)
        {
            bool isActive = (i == selectedStage);

            if (isActive) stageParents[i].SetActive(true);
            else stageParents[i].SetActive(false);
        }

        SpawnCharacters(selectedStage);
    }

    public void SpawnCharacters(int selectedStage) // ĳ���� ����
    {
        Transform stagePosition = stageParents[selectedStage].transform;
        Transform RedSpawn = stagePosition.Find("RedSpawn");
        Transform BlueSpawn = stagePosition.Find("BlueSpawn");

        foreach (var Redplayer in GameObject.FindGameObjectsWithTag("RedPlayer"))
        {
            Destroy(Redplayer);
        }

        foreach (var Blueplayer in GameObject.FindGameObjectsWithTag("BluePlayer"))
        {
            Destroy(Blueplayer);
        }

        GameObject RedPlayer = Instantiate(RedPlayerPrefab, RedSpawn.position, Quaternion.identity);
        GameObject BluePlayer = Instantiate(BluePlayerPrefab, BlueSpawn.position, Quaternion.identity);
    }

    public void ToNextStage(int nextStageIndex) //���� �������� ��ȯ
    {
        if (nextStageIndex < stageParents.Length)
        {
            ChangeStage(nextStageIndex);
            GameManager.Instance.selectedStage = nextStageIndex;
        }
        else
        {
            GameManager.Instance.ReturnToSelectingStage();
        }
    }
}
