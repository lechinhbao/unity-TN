using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    public int manaAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerScript player = other.GetComponent<PlayerScript>();
            if (player != null)
            {
                player.IncreaseMana(manaAmount);
                Destroy(gameObject);
            }
        }
    }
}
