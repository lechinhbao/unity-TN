using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Climb : MonoBehaviour
{

    private float vertical;
    private float speed = 80f;
    private bool isLadder;
    private bool isClimbing;
    private Animator animator;
    //[SerializeField] private Rigidbody2D rb;
    private Rigidbody2D rb;
    private void Start()

    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");

        if (isLadder && Mathf.Abs(vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, vertical * speed);
        }
        else
        {
            rb.gravityScale = 4f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Thang"))
        {
            isLadder = true;
        }
        if (collision.CompareTag("Thang"))
        {
            animator.SetTrigger("IsClimbing");
        }
 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Thang"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}