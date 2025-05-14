using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSwordManager : MonoBehaviour
{
    public GameObject flyingSwordPrefab;  
    public Transform spawnPoint;           
    public float spawnInterval = 4f;      

    void Start()
    {

        InvokeRepeating("SpawnFlyingSword", spawnInterval, spawnInterval);
    }
    private void OnDisable()
    {
        CancelInvoke("SpawnFlyingSword"); //��Ȱ��ȭ�Ǹ� �ڵ����� �ݺ� �ߴ�
    }
    void SpawnFlyingSword()
    {
        if (flyingSwordPrefab != null)
        {
            Instantiate(flyingSwordPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("FlyingSword ������ �ҽ�");
        }
    }
}
