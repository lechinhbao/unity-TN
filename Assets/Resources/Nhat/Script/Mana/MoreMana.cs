using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreMana: MonoBehaviour
{
    public int manaAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ManaScript player = other.GetComponent<ManaScript>();
            if (player != null)
            {
                player.IncreaseMana(manaAmount);
                Destroy(gameObject); 
            }
        }
    }
}
