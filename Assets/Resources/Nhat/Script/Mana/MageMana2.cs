using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMana2 : MonoBehaviour
{
    public int manaAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Mage2 player = other.GetComponent<Mage2>();
            if (player != null)
            {
                player.IncreaseMana(manaAmount);
                Destroy(gameObject);
            }
        }
    }
}
