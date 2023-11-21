using UnityEngine;

public class Climb : MonoBehaviour
{
    public float climbSpeed = 4f;
    public Animator animator;

    private bool isClimbing = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (isClimbing)
        {
            Climb2(verticalInput);
        }
        else
        {
            // Kiểm tra va chạm với box collider để bắt đầu leo
            Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Thang"));

            if (hitCollider != null && verticalInput > 0)
            {
                StartClimbing();
            }
        }

        // Cập nhật trạng thái animation
        animator.SetBool("isClimbing", isClimbing);
    }

    void StartClimbing()
    {
        isClimbing = true;
        rb.gravityScale = 0f; // Ngừng sử dụng trọng lực
    }

    void StopClimbing()
    {
        isClimbing = false;
        rb.gravityScale = 1f; // Bật lại trọng lực
    }

    void Climb2(float verticalInput)
    {
        // Di chuyển nhân vật lên và xuống
        transform.Translate(Vector3.up * verticalInput * climbSpeed * Time.deltaTime);

        // Kiểm tra nếu nhân vật không còn chạm vào box collider nữa thì dừng leo
        Collider2D hitCollider = Physics2D.OverlapCircle(transform.position, 0.2f, LayerMask.GetMask("Climbable"));
        if (hitCollider == null)
        {
            StopClimbing();
        }
    }
}
