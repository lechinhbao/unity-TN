using UnityEngine;

public class BossHurtScript : MonoBehaviour
{
    private Animator bossAnimator;

    void Start()
    {
        // Lấy tham chiếu đến Animator của boss
        bossAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra nếu đối tượng chạm vào có tag "Player"
        if (other.CompareTag("Player"))
        {
            // Bật animation "Hurt"
            bossAnimator.SetTrigger("Hurt");
        }
    }
}
