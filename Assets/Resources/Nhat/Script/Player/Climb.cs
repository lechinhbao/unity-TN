

using UnityEngine;

public class Climb : MonoBehaviour
{
    public float climbSpeed = 3f;
    private Rigidbody2D rb2d;
    private bool isClimbing = false;
    private Animator animator;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isClimbing)
        {
            // Xử lý các hành động khi đang leo lên
            float verticalInput = Input.GetAxis("Vertical");
            Vector2 climbVelocity = new Vector2(rb2d.velocity.x, verticalInput * climbSpeed);
            rb2d.velocity = climbVelocity;
        }
        else
        {
            // Xử lý các hành động khi không leo lên
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem có va chạm với đối tượng thang hay không
        if (other.CompareTag("Thang"))
        {
            StartClimbing();
            animator.SetTrigger("IsClimb");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // Kiểm tra xem đã rời khỏi đối tượng thang hay không
        if (other.CompareTag("Thang"))
        {
            StopClimbing();
            animator.ResetTrigger("IsClimb");
        }
    }

    void StartClimbing()
    {
        isClimbing = true;
        rb2d.gravityScale = 0f; // Tắt trọng lực để nhân vật không bị rơi
    }

    void StopClimbing()
    {
        isClimbing = false;
        rb2d.gravityScale = 1f; // Bật lại trọng lực khi dừng leo lên
    }
}
