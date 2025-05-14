using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiquidWater : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RedPlayer"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
