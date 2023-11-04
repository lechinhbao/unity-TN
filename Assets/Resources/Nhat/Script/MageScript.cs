using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public class MageScript : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private bool isRunning;
    private bool isJumping;

    private float runSpeed = 5f;
    private float jumpForce = 5.5f;

    //Bụi
    public ParticleSystem psBui;
    //Nhãy
    private int jumpCount = 0; // Số lần đã nhảy
    public int maxJumps = 2; // Số lần nhảy tối đa, trong trường hợp này là 2

    private bool isRight = true;
    // Coin
    // public TMP_Text txtCoin;
    private int countCoin = 0;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Vector2 scale = transform.localScale;
        // Điều khiển chạy
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * runSpeed, rb.velocity.y);
        
        isRunning = Mathf.Abs(move) > 0;

        Quaternion rotation = psBui.transform.localRotation;
        
        /*if (Input.GetKey(KeyCode.RightArrow))
        {
            psBui.Play();
            animator.SetBool("IsRunning", true);
            scale.x = 1;
            rotation.y = 180;
            transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            psBui.Play();
            animator.SetBool("IsRunning", true);
            scale.x = -1;
            rotation.y = 0;
            transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }*/
        //Mũi tên trái phải
        if (move != 0)
         {
             if (move < 0)
             {
                 isRight = true;
                 transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
                 psBui.Play();
                 rotation.y = 0;
                 psBui.transform.localRotation = rotation;
             }
             else
             {
                 isRight = false;
                 transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                 psBui.Play();
                 rotation.y = 180;
                 psBui.transform.localRotation = rotation;
             }
         }
        // Điều khiển nhảy
        /*if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            isJumping = true;           
        }
        jumpCount++;
        if (jumpCount == 2)
        {
            animator.SetTrigger("IsHighJump"); // Kích hoạt animation lộn
            jumpCount = 0; // Đặt lại số lần nhảy
        }else if(jumpCount < 2)
        {
            animator.ResetTrigger("IsHighJump");
        }  */
        // Cập nhật trạng thái của Animator
        animator.SetBool("IsRunning", isRunning);
       // animator.SetBool("IsJumping", isJumping);
    }
private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với mặt đất (hoặc các platform)
        if (collision.gameObject.CompareTag("Stone"))
        {
            isJumping = false;
        }
        else if (collision.gameObject.CompareTag("Die"))
        {
            Destroy(gameObject);
        }
    }
    public void Death()
    {
        animator.SetTrigger("IsDeath");
    }
    //Coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            // soundCoin.Play();
            countCoin += 1;
            //txtCoin.text = countCoin + " X";
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "checkpoint")
        {
            //   SavePosition();
        }
    }
}



