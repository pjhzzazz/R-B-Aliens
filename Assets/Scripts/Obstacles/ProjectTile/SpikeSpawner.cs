using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public float interval = 3.5f;
    public GameObject spikeTopPrefab;
    public GameObject spikeBottomPrefab;
    public Transform topSpawnPoint;
    public Transform bottomSpawnPoint;

    private void Start()
    {
        InvokeRepeating("SpawnSpike", interval, interval);
    }

    private void OnDisable()
    {
        CancelInvoke("SpawnSpike"); //��Ȱ��ȭ�Ǹ� �ڵ����� �ݺ� �ߴ�
    }
    void SpawnSpike()
    {

            Instantiate(spikeTopPrefab, topSpawnPoint.position, Quaternion.identity);
             
            Instantiate(spikeBottomPrefab, bottomSpawnPoint.position, Quaternion.identity);
     
    }
}
