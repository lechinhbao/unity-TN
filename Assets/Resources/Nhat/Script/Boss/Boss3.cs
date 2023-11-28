using UnityEngine;

public class Boss3 : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3f;
    public float attackDistance = 2f;
    public float returnDistance = 8f;
    private Animator animator;

    private Vector3 initialPosition;
    private bool isAttacking = false;

    void Start()
    {
        initialPosition = transform.position;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackDistance)
        {
            // Boss gặp nhân vật, đi theo và đánh
            MoveTowardsPlayer();

            if (!isAttacking)
            {
                animator.SetTrigger("IsWalk");
                isAttacking = true;
            }
        }
        else if (distanceToPlayer > returnDistance)
        {
            // Nếu khoảng cách lớn hơn một ngưỡng, boss quay về vị trí ban đầu
            ReturnToInitialPosition();

            if (isAttacking)
            {
                animator.ResetTrigger("IsWalk");
                isAttacking = false;
            }
        }
        else
        {
            // Khoảng cách ở giữa attackDistance và returnDistance, tắt trigger walk
            if (isAttacking)
            {
                animator.ResetTrigger("IsWalk");
                isAttacking = false;
            }
        }
    }

    void MoveTowardsPlayer()
    {
        // Di chuyển boss đến vị trí của nhân vật
        transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);

        // Xác định hướng của nhân vật
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Đặt FlipX dựa trên hướng di chuyển
        if (directionToPlayer.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Không flip
        }
        else if (directionToPlayer.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Flip theo trục X
        }
    }

    void ReturnToInitialPosition()
    {
        // Quay về vị trí ban đầu
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, moveSpeed * Time.deltaTime);
    }

    // Phương thức được gọi khi Boss chạm vào nhân vật
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Bật animation đánh
            animator.SetTrigger("IsAttack");
        }
        else
        {
            animator.ResetTrigger("IsAttack");
        }
    }

}
