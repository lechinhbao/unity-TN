using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth;
    int currentHealth;

    public int Health;
    public int Enemy;
    public int Trap;
    public HealthBar healthBar;


    public UnityEvent OnDeath;

    private Animator animator;
    public float deathAnimationDuration = 2.0f;

    //Hiển thị panel
    public GameObject DiePanel;
    private bool isGamePaused = false;

    //Hurt
    private bool PlayerHurt = false;

    //Popup
    public GameObject popUpDamagePrefabs;
    public TMP_Text popUpText;
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

        //Popup
        popUpText.text = damage.ToString();
        Instantiate(popUpDamagePrefabs, transform.position, Quaternion.identity);

        if (currentHealth < 0) {
            currentHealth = 0;
            OnDeath.Invoke();
        }
        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    //Cộng Máu
    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        healthBar.UpdateBar(currentHealth, maxHealth);
    }
    public void Death()
    {
        // Kích hoạt animation "Die".
        animator.SetTrigger("IsDeath");

        // Chờ cho đến khi animation hoàn thành trước khi hủy GameObject.
        StartCoroutine(DestroyAfterAnimation());
      //Destroy(gameObject);
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Chờ đợi thời gian của animation chết hoàn thành.
        yield return new WaitForSeconds(deathAnimationDuration);

        // Hủy (destroy) GameObject.
        // Destroy(gameObject);

        Time.timeScale = 0; // Tạm dừng thời gian trong trò chơi.
        isGamePaused = true;
        DiePanel.SetActive(true); // Hiển thị Panel Pause.
    }
    
    private void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            PlayerHurt = true;
            // Kích hoạt animation
            animator.SetBool("IsHurt", true);
            TakeDamage(Health);
        }
        if (collision.gameObject.CompareTag("Enemy")){
            PlayerHurt = true;
            // Kích hoạt animation
            animator.SetBool("IsHurt", true);
            TakeDamage(Enemy);
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerHurt = true;
            // Kích hoạt animation
            animator.SetBool("IsHurt", true);
            TakeDamage(Trap);
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            animator.SetTrigger("IsDeath");
            gameObject.SetActive(false);
            Time.timeScale = 0; // Tạm dừng thời gian trong trò chơi.
            isGamePaused = true;
            DiePanel.SetActive(true); // Hiển thị Panel Pause.
          
        }
        if (collision.gameObject.CompareTag("MapDie"))
        {
            gameObject.SetActive(false);
            DiePanel.SetActive(true); // Hiển thị Panel Pause.
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            PlayerHurt = false;
            animator.SetBool("IsHurt", false);

        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHurt = false;
            animator.SetBool("IsHurt", false);

        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            PlayerHurt = false;
            animator.SetBool("IsHurt", false);

        }
    }

}
