using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    //Khai báo biến để tạo máu
    public Slider enemyHealthSlider;
    void Start()
    {
       currentHealth = maxHealth;

       enemyHealthSlider.maxValue = maxHealth;
       enemyHealthSlider.value = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            TakeDamage(10); // Giả sử khi va chạm với quái vật, nhân vật mất 10 máu
        }
    }
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        enemyHealthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            makeDead();
        }
        void makeDead()
        {
            Destroy (gameObject);
          
        }

    }

}
