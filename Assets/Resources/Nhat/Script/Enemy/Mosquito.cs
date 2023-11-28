using UnityEngine;

public class Mosquito : MonoBehaviour
{
    public float speed = 3f;
    public float attackDistance = 2f;
    public float retreatDistance = 5f;
    public float attackCooldown = 2f;
    private bool isAttacking = false;
    private Vector3 initialPosition;
    private Transform player;
    public float rotationSpeed = 5f;
    void Start()
    {
        // Lưu vị trí ban đầu của enemy
        initialPosition = transform.position;

        // Lấy thông tin về người chơi (nhân vật)
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        // Kiểm tra khoảng cách giữa enemy và người chơi
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // Nếu khoảng cách nhỏ hơn hoặc bằng attackDistance và không phải đang tấn công, thì tấn công
        if (distanceToPlayer <= attackDistance && !isAttacking)
        {
            isAttacking = true;
            InvokeRepeating("IsAttack", 0f, attackCooldown);
        }
        else if (isAttacking)
        {
            CancelInvoke("IsAttack");
            isAttacking = false;
        }

        // Nếu khoảng cách lớn hơn retreatDistance, enemy sẽ bay về chỗ cũ
        if (distanceToPlayer > retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
        }
        else
        {
            // Di chuyển enemy theo hướng người chơi
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        }

    }

    void Attack()
    {
        // Xử lý tấn công ở đây (ví dụ: gửi thông báo tấn công cho nhân vật)
        Debug.Log("Enemy tấn công!");
    }

}
