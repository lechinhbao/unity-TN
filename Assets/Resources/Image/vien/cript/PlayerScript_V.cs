using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript_V : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
   
    private bool isRunning;
    private bool isJumping;

    public float runSpeed = 5f;
    public float jumpForce = 5f;

    private bool isFacingRight = true;


    //toc bien
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    [SerializeField] private TrailRenderer tr;
                

    private void Start()

    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
       //toc bien
       if(isDashing)
        {
            return;
        }

        // Điều khiển chạy
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
        isRunning = Mathf.Abs(move) > 0;
    
    
        if(move != 0)
        {
            if (move < 0)
            {
                transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
            }
            else
            {
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            }
        }
        // Xác định hướng nhìn của Player
      /*  if (move > 0 && !isFacingRight)
          {
             Flip();
            Debug.Log("phai");
          }
          else if (move < 0 && isFacingRight)
          {
              Flip();
          }*/

        // Điều khiển nhảy
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }

        // Cập nhật trạng thái của Animator
        animator.SetBool("IsRunning", isRunning);
        animator.SetBool("IsJumping", isJumping);


        //toc bien
        if(Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }
    }

  /* private void Flip()
    {
        // Đảo ngược hướng nhìn của Player
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= 1;
        transform.localScale = scale;
    }*/
   
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

    //toc bien
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    private void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
    }


}



