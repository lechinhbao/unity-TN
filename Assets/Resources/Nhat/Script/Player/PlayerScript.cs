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
    //private bool isJumping;

    public float runSpeed = 5f;
   // public float jumpForce = 5f;

    //private bool isFacingRight = true;

    //Coin
    public TMP_Text txtCoin;
    private int countCoin = 0;

    //Bắn đạn
    private bool isRight = true;

    //Bụi
    public ParticleSystem psBui;
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

        //Bụi
        Quaternion rotation = psBui.transform.localRotation;

        if (move != 0)
        {
            if (move < 0)
            {       
                transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
                isRight = false;
                //Bụi
                psBui.Play();
                rotation.y = 0;
                psBui.transform.localRotation = rotation;
            }
            else
            {
                transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
                isRight = true;
                //Bụi
                psBui.Play();
                rotation.y = 180;
                psBui.transform.localRotation = rotation;
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
        // Điều khiển nhảy
        // if (Input.GetButtonDown("Jump") && !isJumping)
        // {
        //     rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        //      isJumping = true;
        //  }

        // Cập nhật trạng thái của Animator
        animator.SetBool("IsRunning", isRunning);
        
        // animator.SetBool("IsJumping", isJumping);

        //Bắn đạn
        if (Input.GetKeyDown(KeyCode.K))
        {
            var x = transform.position.x + (isRight ? 0.5f : -0.5f);
            var y = transform.position.y;
            var z = transform.position.z;

            GameObject gameObject = (GameObject)Instantiate(
            Resources.Load("Nhat/PrefabsBullet/Phitieu"),
            new Vector3(x, y, z),
            Quaternion.identity
            );
            gameObject.GetComponent<Fire>().setIsRight(isRight);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với mặt đất (hoặc các platform)
        if (collision.gameObject.CompareTag("Stone"))
        {
            //isJumping = false;
        }
        else if(collision.gameObject.CompareTag("Die"))
        {
            //Destroy(gameObject);
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



