using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    //Bụi
    public ParticleSystem psBui;
    //đếm thời gian chơi
    private int time; //Thời gian tính băng giây
    public TMP_Text timeTextVictory; //Hiển thị thời gian chơi
    private bool isAlive; //Kiểm tra nhân vật tương tác

    public GameObject[] playerPerfabs;
    int characterIndex;
    public static Vector2 DHS = new Vector2((float)56,(float)3);

    public static int numberOfCoins;
    public TextMeshProUGUI coinsText;

    private void Awake()
    {
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(playerPerfabs[characterIndex], DHS, Quaternion.identity);
    }

    //Heath
    [SerializeField] int maxHealth;
    int currentHealth;

    public int Health;
    public int Enemy;
    public int Trap;
    public int FireEnemy = 10;
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

    //Mana
    [SerializeField] int currentMana;

    public Mana manaBar;

    //private Animator animator;
    public int maxMana = 100;

    public float manaIncreaseInterval = 5f; // Thời gian để tăng thêm mana (10 giây trong trường hợp này)
    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.UpdateBar(currentHealth, maxHealth);
        animator = GetComponent<Animator>();

        currentMana = maxMana;
        manaBar.UpdateMana(currentMana, maxMana);
        // animator = GetComponent<Animator>();

        InvokeRepeating("IncreaseMana", 0f, manaIncreaseInterval);
    }
    //Time
    IEnumerator UpdateTime()
    {
        while (isAlive)
        {
            time++;
            timeTextVictory.text = "Time:" + time + "s";
            yield return new WaitForSeconds(1);
        }
    }
    //Hồi mana
    void IncreaseMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += 5; // Tăng thêm 10 mana sau mỗi khoảng thời gian
            manaBar.UpdateMana(currentMana, maxMana);
        }
    }
    public void TakeMana(int mana)
    {
        currentMana -= mana;

        if (currentMana < 0)
        {
            currentMana = 0;
            //animator.ResetTrigger("Attack");
            animator.ResetTrigger("IsAttackExtra");
            animator.ResetTrigger("IsWalkAttack");
            animator.ResetTrigger("IsRunAttack");
            animator.ResetTrigger("IsBullet");

        }
        manaBar.UpdateMana(currentMana, maxMana);
    }
    //Cộng Mana khi ăn xu
    public void IncreaseMana(int amount)
    {
        currentMana += amount;

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        manaBar.UpdateMana(currentMana, maxMana);
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        //Popup
        popUpText.text = damage.ToString();
        Instantiate(popUpDamagePrefabs, transform.position, Quaternion.identity);

        if (currentHealth < 0)
        {
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

    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Chờ đợi thời gian của animation chết hoàn thành.
        yield return new WaitForSeconds(deathAnimationDuration);

        // Hủy (destroy) GameObject.
        // Destroy(gameObject);
        gameObject.SetActive(false);

        Time.timeScale = 0; // Tạm dừng thời gian trong trò chơi.
        isGamePaused = true;
        DiePanel.SetActive(true); // Hiển thị Panel Pause.
    }

    //Mana

   private void Update()
    {
        coinsText.text = numberOfCoins.ToString();


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
        if (collision.gameObject.CompareTag("Enemy"))
        {
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
        if (collision.gameObject.CompareTag("fireBall"))
        {
            PlayerHurt = true;
            // Kích hoạt animation
            animator.SetBool("IsHurt", true);
            TakeDamage(FireEnemy);
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
    //Enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHurt = true;
            // Kích hoạt animation
            animator.SetBool("IsHurt", true);
            TakeDamage(FireEnemy);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHurt = false;
            // Kích hoạt animation
            animator.SetBool("IsHurt", false);
        }
    }
}


