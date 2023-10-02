using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Kiểm tra nếu máu dưới 0
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Xử lý khi nhân vật chết
        // Ví dụ: kết thúc trò chơi hoặc khởi động lại nhân vật
    }
}