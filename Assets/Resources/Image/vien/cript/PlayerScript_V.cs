using System.Collections;
using System.Collections.Generic;
using TMPro;
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
<<<<<<< HEAD:Assets/Resources/Nhat/Script/PlayerScript.cs
    //Coin
    public TMP_Text txtCoin;
    private int countCoin = 0;
=======


    //toc bien
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 0.5f;

    [SerializeField] private TrailRenderer tr;
                
>>>>>>> Vien:Assets/Resources/Image/vien/cript/PlayerScript_V.cs

    private void Start()

    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
<<<<<<< HEAD:Assets/Resources/Nhat/Script/PlayerScript.cs
       
=======
       //toc bien
       if(isDashing)
        {
            return;
        }
>>>>>>> Vien:Assets/Resources/Image/vien/cript/PlayerScript_V.cs

        // Điều khiển chạy
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
        isRunning = Mathf.Abs(move) > 0;
    
    
        if(move != 0)
        {
            if (move < 0)
<<<<<<< HEAD:Assets/Resources/Nhat/Script/PlayerScript.cs
            {       
=======
            {
>>>>>>> Vien:Assets/Resources/Image/vien/cript/PlayerScript_V.cs
                transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
            }
            else
            {
<<<<<<< HEAD:Assets/Resources/Nhat/Script/PlayerScript.cs
  
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
=======
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

>>>>>>> Vien:Assets/Resources/Image/vien/cript/PlayerScript_V.cs
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
<<<<<<< HEAD:Assets/Resources/Nhat/Script/PlayerScript.cs
=======

  /* private void Flip()
    {
        // Đảo ngược hướng nhìn của Player
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= 1;
        transform.localScale = scale;
    }*/
>>>>>>> Vien:Assets/Resources/Image/vien/cript/PlayerScript_V.cs
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với mặt đất (hoặc các platform)
        if (collision.gameObject.CompareTag("Stone"))
        {
            isJumping = false;
        }
<<<<<<< HEAD:Assets/Resources/Nhat/Script/PlayerScript.cs
        else if(collision.gameObject.CompareTag("Die"))
        {
            Destroy(gameObject);
        }
=======
>>>>>>> Vien:Assets/Resources/Image/vien/cript/PlayerScript_V.cs
     
    }
    public void Death()
    {
        animator.SetTrigger("PlayerDeath");
       
    }
<<<<<<< HEAD:Assets/Resources/Nhat/Script/PlayerScript.cs
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
=======

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
>>>>>>> Vien:Assets/Resources/Image/vien/cript/PlayerScript_V.cs
        }
    }


}



