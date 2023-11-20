using UnityEngine;

public class Kiem : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        // Lấy Animator component của đối tượng
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Xử lý sự kiện nhấn nút đánh (ví dụ: space)
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Kích hoạt trạng thái đánh bằng cách sử dụng trigger
            animator.SetTrigger("Kiem");
        }
        else {
            animator.ResetTrigger("Kiem");
        }
    }
}
