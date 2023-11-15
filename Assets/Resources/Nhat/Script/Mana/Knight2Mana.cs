using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight2Mana: MonoBehaviour
{
    public int manaAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Knight2 player = other.GetComponent<Knight2>();
            if (player != null)
            {
                player.IncreaseMana(manaAmount);
                Destroy(gameObject);
            }
        }
    }
}
