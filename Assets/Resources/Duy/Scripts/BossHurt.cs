using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHurt : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu đối tượng mà boss va chạm có tag là "Player"
        if (other.CompareTag("Player"))
        {
            // Bật animation "hurt"
            animator.SetTrigger("IsHurt");

            // Thực hiện các hành động khác khi boss bị tổn thương
            // Ví dụ: giảm điểm máu của boss, gọi hàm xử lý tổn thương, vv.
        }
    }
}
