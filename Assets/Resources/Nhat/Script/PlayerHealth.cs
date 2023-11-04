using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;

    public int Health;
    public int DamageEnemy;
    public int Trap;
    public HealthBar healthBar;

    public UnityEvent OnDeath;

    private Animator animator;
    public float deathAnimationDuration = 2.0f;

    //Hiển thị panel
    public GameObject DiePanel;
    private bool isGamePaused = false;

    //Hurt
    private bool IsHurt = false;
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
        animator.SetTrigger("IsDeath");

        // Chờ cho đến khi animation hoàn thành trước khi hủy GameObject.
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Chờ đợi thời gian của animation chết hoàn thành.
        yield return new WaitForSeconds(deathAnimationDuration);

        Time.timeScale = 0; // Tạm dừng thời gian trong trò chơi.
        isGamePaused = true;
        DiePanel.SetActive(true); // Hiển thị Panel Pause.
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
            IsHurt = true;
            // Kích hoạt animation
            animator.SetBool("IsHurt", true);
            TakeDamage(Health);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IsHurt = true;
            // Kích hoạt animation
            animator.SetBool("IsHurt", true);
            TakeDamage(DamageEnemy);
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            IsHurt = true;
            // Kích hoạt animation
            animator.SetBool("IsHurt", true);
            TakeDamage(Trap);
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            IsHurt = false;
            // Kích hoạt animation
            animator.SetBool("IsHurt", false);

        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            IsHurt = false;
            // Kích hoạt animation
            animator.SetBool("IsHurt", false);
            TakeDamage(DamageEnemy);
        }
    }
}
