﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    private Animator animator;
    public float deathAnimationDuration = 2.0f;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
        animator = GetComponent<Animator>();
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth / (float)maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamagePlayer"))
        {
            
            TakeDamage(20); // Giả sử khi va chạm với quái vật, nhân vật mất 10 máu
        }
    }

            public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Đảm bảo giới hạn máu trong khoảng [0, maxHealth]
        UpdateHealthSlider();

        if (currentHealth <= 0)
        {
            DeathEnemy();
        }
    }
    public void DeathEnemy()
    {
        // Kích hoạt animation "Die".
        animator.SetTrigger("DworfDie");

        // Chờ cho đến khi animation hoàn thành trước khi hủy GameObject.
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Chờ đợi thời gian của animation chết hoàn thành.
        yield return new WaitForSeconds(deathAnimationDuration);

        // Hủy (destroy) GameObject.
        Destroy(gameObject);
    }
}

