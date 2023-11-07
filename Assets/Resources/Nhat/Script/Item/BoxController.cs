using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab của đối tượng xu
    private int collisionCount = 0;

    public GameObject Effect;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            collisionCount++;
            //Effect
            Instantiate(Effect, transform.position, Quaternion.identity);
            if (collisionCount >= 2)
            {
                DropCoin();
                Destroy(gameObject);
            }
        }
    }

    private void DropCoin()
    {
        Instantiate(coinPrefab, transform.position, Quaternion.identity);
    }
}
