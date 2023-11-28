using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    Transform target;
    public Transform borderCheck;

    public bool isRight, isLeft;
    public GameObject fireBall;
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

        if (time < 0)
        {
            Vector2 scale = transform.localScale;
            if (isRight == true)
            {  
                time = timeSpawn;
                GameObject fb = Instantiate(fireBall);
                fb.transform.position = new Vector2(

                    transform.position.x + (isRight ? 0.1f : -0.1f),
                    transform.position.y

                );
                fb.GetComponent<FireScript>().SetSpeed(
                   isRight ? 4 : -4
                );
                animator.SetBool("IsMagic", true);
            }
             
            else
            {
           
                time = timeSpawn;
                GameObject fb = Instantiate(fireBall);
                fb.transform.position = new Vector2(

                    transform.position.x + (isLeft ? 0.1f : -0.1f),
                    transform.position.y

                );
                fb.GetComponent<FireScript>().SetSpeed(
                   isLeft ? 4 : -4
                );
                animator.SetBool("IsMagic", true);
            }

        }
        else
        {
            // Stop the "Magic" animation
            animator.SetBool("IsMagic", false);
        }


    }

  /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // Kích hoạt animation
            animator.SetBool("IsHurt", true);

        }
        if (collision.gameObject.CompareTag("Bullet"))
        {

            // Kích hoạt animation
            animator.SetBool("IsHurt", true);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            // Kích hoạt animation
            animator.SetTrigger("IsHurt");

        }
    }*/

}
