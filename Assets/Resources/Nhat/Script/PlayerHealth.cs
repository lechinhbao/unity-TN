using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;

    public HealthBar healthBar;
    public UnityEvent OnDeath;

    private Animator animator;

    public float deathAnimationDuration = 2.0f;
    private void OnEnable()
    {
        OnDeath.AddListener(Death);
    }
    private void OnDisable()
    {
        OnDeath.RemoveListener(Death);
    }
    public void Start()
    {
        currentHealth = maxHealth;

       healthBar.UpdateBar(currentHealth, maxHealth);
        animator = GetComponent<Animator>();
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0) {
            currentHealth = 0;
            OnDeath.Invoke();
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    public void Death()
    {
        // Kích hoạt animation "Die".
        animator.SetTrigger("PlayerDeath");

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

    private void Update()
    {
   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            TakeDamage(10);
        }
    }
}
