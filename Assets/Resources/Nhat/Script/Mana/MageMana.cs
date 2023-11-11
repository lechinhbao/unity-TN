using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMana : MonoBehaviour
{
    public int manaAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MageScript player = other.GetComponent<MageScript>();
            if (player != null)
            {
                player.IncreaseMana(manaAmount);
                Destroy(gameObject);
            }
        }
    }
}
