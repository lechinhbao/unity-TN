using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    //Coin
    public TMP_Text txtCoin;
    private int countCoin = 0;

    private void Start()

    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
       

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
        if (move != 0)
        {
            if (move < 0 && Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("RunAttack");
                Debug.Log("Đa bat");
            }
            else if(move > 0 && Input.GetKeyDown(KeyCode.F))
            {
                animator.SetTrigger("RunAttack");
                Debug.Log("Đa bat");
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
    //Coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
           // soundCoin.Play();
            countCoin += 1;
            txtCoin.text = countCoin + " X";
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "checkpoint")
        {
         //   SavePosition();
        }
    }


}



