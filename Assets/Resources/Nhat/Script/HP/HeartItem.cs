using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    public int healthAmount = 20; // Số lượng máu mà trái tim sẽ cung cấp

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth player = other.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.IncreaseHealth(healthAmount);
                Destroy(gameObject); // Xóa trái tim sau khi ăn
            }
        }
    }
}
