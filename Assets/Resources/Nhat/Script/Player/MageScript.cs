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

    public float runSpeed = 5f;

    //Bắn đạn
    private bool isRight = true;

    //Bụi
    public ParticleSystem psBui;

    //Mana
    public int maxMana = 100; // Số mana tối đa
    public int currentMana;
    public Mana manaBar;

    public float manaIncreaseInterval = 5f; // Thời gian để tăng thêm mana (10 giây trong trường hợp này)
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        currentMana = maxMana;
        manaBar.UpdateMana(currentMana, maxMana);

        InvokeRepeating("IncreaseMana", 0f, manaIncreaseInterval);
    }
    //Hồi mana
    void IncreaseMana()
    {
        if (currentMana < maxMana)
        {
            currentMana += 5; // Tăng thêm 10 mana sau mỗi khoảng thời gian
            manaBar.UpdateMana(currentMana, maxMana);
        }
    }
    public void IncreaseMana(int amount)
    {
        currentMana += amount;

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }

        manaBar.UpdateMana(currentMana, maxMana);
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
        animator.SetBool("IsRunning", isRunning);
        // Điều khiển nhảy
        // if (Input.GetButtonDown("Jump") && !isJumping)
        // {
        //     rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        //      isJumping = true;
        //  }

        // Cập nhật trạng thái của Animator


        // animator.SetBool("IsJumping", isJumping);


        //Bắn đạn
/*        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentMana > 0)
            {
                var x = transform.position.x + (isRight ? 0.5f : -0.5f);
                var y = transform.position.y;
                var z = transform.position.z;

                GameObject gameObject = (GameObject)Instantiate(
                Resources.Load("Nhat/PrefabsBullet/Fire"),
                new Vector3(x, y, z),
                Quaternion.identity
                );
                gameObject.GetComponent<Fire>().setIsRight(isRight);
            }
            else if(currentMana <= 0)
            {
                Debug.Log("Không đủ mana");
            }

        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            var x = transform.position.x + (isRight ? 0.5f : -0.5f);
            var y = transform.position.y;
            var z = transform.position.z;

            GameObject gameObject = (GameObject)Instantiate(
            Resources.Load("Nhat/PrefabsBullet/FireExtra"),
            new Vector3(x, y, z),
            Quaternion.identity
            );
            gameObject.GetComponent<Fire>().setIsRight(isRight);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            var x = transform.position.x + (isRight ? 0.5f : -0.5f);
            var y = transform.position.y;
            var z = transform.position.z;

            GameObject gameObject = (GameObject)Instantiate(
            Resources.Load("Nhat/PrefabsBullet/Comet"),
            new Vector3(x, y, z),
            Quaternion.identity
            );
            gameObject.GetComponent<Fire>().setIsRight(isRight);

        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            var x = transform.position.x + (isRight ? 0.5f : -0.5f);
            var y = transform.position.y;
            var z = transform.position.z;

            GameObject gameObject = (GameObject)Instantiate(
            Resources.Load("Nhat/PrefabsBullet/Fire2"),
            new Vector3(x, y, z),
            Quaternion.identity
            );
            gameObject.GetComponent<Fire>().setIsRight(isRight);

        }*/
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentMana >= 5) // Kiểm tra nếu mana đủ để bắn (10 mana trong trường hợp này)
            {
                Shoot();
                currentMana -= 5; // Trừ đi 10 mana sau khi bắn
                manaBar.UpdateMana(currentMana, maxMana);
            }
            else
            {
                Debug.Log("Không đủ mana để bắn đạn!");
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (currentMana >= 5) // Kiểm tra nếu mana đủ để bắn (10 mana trong trường hợp này)
            {
                Shoot2();
                currentMana -= 5; // Trừ đi 10 mana sau khi bắn
                manaBar.UpdateMana(currentMana, maxMana);
            }
            else
            {
                Debug.Log("Không đủ mana để bắn đạn!");
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentMana >= 5) // Kiểm tra nếu mana đủ để bắn (10 mana trong trường hợp này)
            {
                Shoot3();
                currentMana -= 5; // Trừ đi 10 mana sau khi bắn
                manaBar.UpdateMana(currentMana, maxMana);
            }
            else
            {
                Debug.Log("Không đủ mana để bắn đạn!");
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (currentMana >= 5) // Kiểm tra nếu mana đủ để bắn (10 mana trong trường hợp này)
            {
                Shoot4();
                currentMana -= 5; // Trừ đi 10 mana sau khi bắn
                manaBar.UpdateMana(currentMana, maxMana);
            }
            else
            {
                Debug.Log("Không đủ mana để bắn đạn!");
            }
        }
    }
    void Shoot()
    {
        var x = transform.position.x + (isRight ? 0.5f : -0.5f);
        var y = transform.position.y;
        var z = transform.position.z;

        GameObject gameObject = (GameObject)Instantiate(
        Resources.Load("Nhat/PrefabsBullet/Fire"),
        new Vector3(x, y, z),
        Quaternion.identity
        );
        gameObject.GetComponent<Fire>().setIsRight(isRight);
    }
    void Shoot2()
    {
            var x = transform.position.x + (isRight ? 0.5f : -0.5f);
            var y = transform.position.y;
            var z = transform.position.z;

            GameObject gameObject = (GameObject)Instantiate(
             Resources.Load("Nhat/PrefabsBullet/FireExtra"),
            new Vector3(x, y, z),
            Quaternion.identity
            );
            // Set additional properties if needed
            gameObject.GetComponent<Fire>().setIsRight(isRight);
       
    }
    void Shoot3()
    {
        var x = transform.position.x + (isRight ? 0.5f : -0.5f);
        var y = transform.position.y;
        var z = transform.position.z;

        GameObject gameObject = (GameObject)Instantiate(
        Resources.Load("Nhat/PrefabsBullet/Comet"),
        new Vector3(x, y, z),
        Quaternion.identity
        );
        gameObject.GetComponent<Fire>().setIsRight(isRight);
    }
    void Shoot4()
    {
        var x = transform.position.x + (isRight ? 0.5f : -0.5f);
        var y = transform.position.y;
        var z = transform.position.z;

        GameObject gameObject = (GameObject)Instantiate(
        Resources.Load("Nhat/PrefabsBullet/SpiralBullet"),
        new Vector3(x, y, z),
        Quaternion.identity
        );
        gameObject.GetComponent<Fire>().setIsRight(isRight);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với mặt đất (hoặc các platform)
        if (collision.gameObject.CompareTag("Stone"))
        {
            //isJumping = false;
        }
        if (collision.gameObject.CompareTag("Die"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BoxPush"))
        {
            animator.SetTrigger("IsPush");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        animator.ResetTrigger("IsPush");
    }
    public void Death()
    {
        animator.SetTrigger("PlayerDeath");

    }

}



