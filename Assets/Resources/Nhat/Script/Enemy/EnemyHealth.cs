using System.Collections;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    private Animator animator;
    public float deathAnimationDuration = 2.0f;

    private bool DworfHurt = false;

    //Popup
    public GameObject popUpDamagePrefab;
    public TMP_Text popUpText;

    public GameObject Effect;

    //CoinDrop
    public GameObject CoinModel;

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

            DworfHurt = true;
            // Kích hoạt animation
            animator.SetBool("IsHurt", true);
            TakeDamage(10); // Giả sử khi va chạm với quái vật, nhân vật mất 10 máu
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DamagePlayer"))
        {
            DworfHurt = false;
            // Kích hoạt animation
            animator.SetBool("IsHurt", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DworfHurt = true;
            // Kích hoạt animation
            animator.SetTrigger("IsHurt");
            TakeDamage(10); 
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DworfHurt = false;
            // Kích hoạt animation
            animator.ResetTrigger("IsHurt");
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Popup
        popUpText.text = damage.ToString();
        Instantiate(popUpDamagePrefab, transform.position, Quaternion.identity);
        //Effect
        Instantiate(Effect, transform.position, Quaternion.identity);

        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Đảm bảo giới hạn máu trong khoảng [0, maxHealth]
        UpdateHealthSlider();

        if (currentHealth <= 0)
        {
            DeathEnemy();
            DropCoin();
        }
    }
    //Drop Coin
    void DropCoin()
    {
        Vector3 position = transform.position;
        GameObject coin = Instantiate(CoinModel,transform.position, Quaternion.identity);
        coin.SetActive(true);
        Destroy(coin, 5f);
    }

public void DeathEnemy()
    {
        // Kích hoạt animation "Die".
        animator.SetTrigger("IsDie");

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

  /*  void ShowDamage(string text)
    {
        if (floatingTextPrefabs)
        {
            GameObject prefabs = Instantiate(floatingTextPrefabs);
            prefabs.GetComponentInChildren<TextMeshPro>().text = text;
        }
    }*/
}

