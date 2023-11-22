using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private Rigidbody2D rb; // Kết nối Rigidbody2D của nhân vật
    private Animator animator; // Kết nối Animator của nhân vật
    public float jumpForce = 5f; // Lực nhảy
    public int maxJumps = 2; // Số lần nhảy tối đa
    private int jumpCount = 0; // Số lần đã nhảy
    private bool isFlipping = false; // Trạng thái lộn
    private void Start()

    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && (jumpCount < maxJumps || jumpCount == 0))
        {
            Jumping();

        }
    }

    void Jumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f); // Đặt lại vận tốc theo trục y
        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        jumpCount++;

        animator.SetTrigger("IsJumping"); // Kích hoạt animation nhảy

        if (jumpCount == 2)
        {
            isFlipping = true;
        }
    }
    void FixedUpdate()
    {
        if (isFlipping)
        {
            animator.SetTrigger("IsHighJump"); // Kích hoạt animation lộn
            isFlipping = false; // Tắt trạng thái lộn
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            animator.ResetTrigger("IsHighJump");
            animator.ResetTrigger("IsJumping");
            jumpCount = 0; // Reset số lần đã nhảy khi tiếp xúc với mặt đất
        }
    }
}

