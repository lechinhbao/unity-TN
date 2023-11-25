using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigKinght : MonoBehaviour
{
    public Transform player; // Tham chiếu đến transform của nhân vật chính (player)
    public float rotationSpeed = 5f;
    public float attackRange = 2f;
    public Animator animator;

    void Update()
    {
        if (player != null)
        {
            // Xác định hướng từ enemy đến player
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.y = 0f; // Đảm bảo chỉ xoay theo trục x và z

            // Xác định khoảng cách đến player
            float distanceToPlayer = directionToPlayer.magnitude;

            // Xác định góc xoay để nhìn vào player
            Quaternion lookRotation = Quaternion.LookRotation(directionToPlayer);

            // Áp dụng xoay cho enemy
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

            // Nếu khoảng cách nhỏ hơn hoặc bằng attackRange, kích hoạt animation tấn công
            if (distanceToPlayer <= attackRange)
            {
                animator.SetBool("IsAttacking", true);
            }
            else
            {
                animator.SetBool("IsAttacking", false);
                // Kích hoạt animation di chuyển khi không ở trong tầm tấn công
                animator.SetBool("IsMoving", true);

                // Di chuyển enemy theo hướng player
                transform.Translate(Vector3.forward * Time.deltaTime);
            }
        }
    }
}
