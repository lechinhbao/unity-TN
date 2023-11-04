using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int minDamage;
    public int maxDamage;
    public bool goodSizeBullet;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !goodSizeBullet)
        {
            int damage = Random.Range(minDamage, maxDamage);
            //collision.GetComponent<PlayerScript>().TakeDamage(damage);
        }
    }
}
