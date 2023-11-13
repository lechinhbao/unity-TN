using UnityEngine;

public class KnockbackOnCollision : MonoBehaviour
{
    public float knockbackForce = 2f;
    public float knockbackHeight = 3f;
    public float knockbackDistance = 2f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với đối tượng enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            KnockbackAction(collision.gameObject);
        }
    }

    void KnockbackAction(GameObject enemy)
    {
        // Lấy component Rigidbody2D của enemy
        Rigidbody2D enemyRigidbody2D = enemy.GetComponent<Rigidbody2D>();

        if (enemyRigidbody2D != null)
        {
            // Tính toán hướng lực văng
            Vector2 knockbackForceVector = new Vector2(0f, knockbackHeight);

            // Áp dụng lực văng
            enemyRigidbody2D.velocity = Vector2.zero; // Đặt vận tốc về 0 trước khi áp dụng lực
            enemyRigidbody2D.AddForce(knockbackForceVector, ForceMode2D.Impulse);

            // Văng ra xa
            Vector2 knockbackDirection = (enemy.transform.position - transform.position).normalized;
            enemyRigidbody2D.AddForce(knockbackDirection * knockbackDistance, ForceMode2D.Impulse);
        }
    }
}
