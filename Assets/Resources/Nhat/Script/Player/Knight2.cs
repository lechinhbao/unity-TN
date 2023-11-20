﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Knight2 : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private bool isRunning;
    //private bool isJumping;

    public float runSpeed = 5f;

    //Bắn đạn
    private bool isRight = true;

    //Bụi
    public ParticleSystem psBui;


    //Hiển thị panel
    public GameObject DiePanel;

    //Mana
    public int maxMana = 100; // Số mana tối đa
    public int currentMana = 100;
    public Mana manaBar;

    public float manaIncreaseInterval = 5f; // Thời gian để tăng thêm mana (10 giây trong trường hợp này)

    //Coin Panel
    public TMP_Text txtCoinVictory;
    private int countCoin = 0;

    //đếm thời gian chơi
    private int time; //Thời gian tính băng giây
    public TMP_Text timeTextVictory; //Hiển thị thời gian chơi
    private bool isAlive; //Kiểm tra nhân vật tương tác

    //Skill
    private bool canShoot = true;
    private void Start()

    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        //Mana
        currentMana = maxMana;
        manaBar.UpdateMana(currentMana, maxMana);

        InvokeRepeating("IncreaseMana", 0f, manaIncreaseInterval);

        //Time panel
        isAlive = true;
        time = 0;
        timeTextVictory.text = "Time:" + time + "s";
        StartCoroutine(UpdateTime());
    }
    //Time
    IEnumerator UpdateTime()
    {
        while (isAlive)
        {
            time++;
            timeTextVictory.text = "Time:" + time + "s";
            yield return new WaitForSeconds(1);
        }
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

        // Cập nhật trạng thái của Animator
        animator.SetBool("IsRunning", isRunning);

        // animator.SetBool("IsJumping", isJumping);

        if (Input.GetKeyDown(KeyCode.E))
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
            // Bắt đầu coroutine để chờ 3 giây trước khi có thể bắn tiếp
            StartCoroutine(RechargeSkill());
        }
        if (Input.GetKeyDown(KeyCode.R))
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

    }
    void Shoot()
    {
        var x = transform.position.x + (isRight ? 0.5f : -0.5f);
        var y = transform.position.y;
        var z = transform.position.z;

        GameObject gameObject = (GameObject)Instantiate(
        Resources.Load("Nhat/PrefabsBullet/Spikes"),
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
        Resources.Load("Nhat/PrefabsBullet/Ice"),
        new Vector3(x, y, z),
        Quaternion.identity
        );
        gameObject.GetComponent<Fire>().setIsRight(isRight);
    }
    IEnumerator RechargeSkill()
    {
        // Đặt biến để tránh bắn liên tục trong khoảng thời gian chờ
        canShoot = false;

        // Đợi 3 giây
        yield return new WaitForSeconds(3f);

        // Sau 3 giây, cho phép bắn lại
        canShoot = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với mặt đất (hoặc các platform)
        if (collision.gameObject.CompareTag("Stone"))
        {
            //isJumping = false;
        }
        else if (collision.gameObject.CompareTag("Die"))
        {
            gameObject.SetActive(false);
            DiePanel.SetActive(true); // Hiển thị Panel Pause.
            //Destroy(gameObject);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            //soundCoin.Play();
            countCoin += 1;
            txtCoinVictory.text = "Score:" + countCoin;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.tag == "checkpoint")
        {
            //SavePosition();
        }
    }
}



