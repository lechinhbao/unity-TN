using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : MonoBehaviour
{

    Transform target;
    public Transform borderCheck;

    public bool isRight, isLeft;
    private float timeSpawn;
    private float time;

    private Animator animator;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        timeSpawn = 10;
        time = timeSpawn;

        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {


        if (target.position.x > transform.position.x)
        {
            isRight = true;
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            isRight = false;
            transform.localScale = new Vector2(-1f, 1f);
        }

        time -= Time.deltaTime;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {

            // Kích hoạt animation
            animator.SetTrigger("IsHurt");

        }
        if (collision.gameObject.CompareTag("Bullet"))
        {

            // Kích hoạt animation
            animator.ResetTrigger("IsHurt");

        }
    }

}
