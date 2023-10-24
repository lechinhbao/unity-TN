using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private bool isRunning;
    private bool isJumping;

    public float runSpeed = 5f;
    public float jumpForce = 5f;

    private bool isFacingRight = true;

    /*//vien dan
    public GameObject fireball;*/

    private void Start()

    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        /*//ban dan
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject fire = Instantiate(fireball);
            fire.transform.position = new Vector3(transform.position.x + (isFacingRight ? 0.5f : -0.5f), transform.position.y, transform.position.z);
            fire.GetComponent<fireball>().SetSpeed(isFacingRight ? 5 : -5);
        }*/

        // Điều khiển chạy
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
        isRunning = Mathf.Abs(move) > 0;


        // Xác định hướng nhìn của Player
        if (move > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && isFacingRight)
        {
            Flip();
        }

        // Điều khiển nhảy
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        // Cập nhật trạng thái của Animator
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsJumping", isJumping);
    }

    private void Flip()
    {
        // Đảo ngược hướng nhìn của Player
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với mặt đất (hoặc các platform)
        if (collision.gameObject.CompareTag("Stone"))
        {
            isJumping = false;
        }

    }
    public void Death()
    {
        animator.SetTrigger("PlayerDeath");

    }


}



