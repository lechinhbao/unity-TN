using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private new Rigidbody2D rigidbody2D;
    private bool isNen;
    private Animator animator;
    private float speed;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 scale = transform.localScale;
        animator.SetBool("isRunning", true);

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isRunning", true );
            scale.x = 1;
            transform.Translate(Vector3.right * 5 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isRunning", true);
            scale.x = -1;
            transform.Translate(Vector3.left * 5 * Time.deltaTime);
        }

        transform.localScale = scale;

        if (Input.GetKey(KeyCode.W))
        {
            if (isNen)
            {
                rigidbody2D.AddForce(new Vector2(0, 100));
                isNen = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Nen")
        {
            isNen = true;
        }
    }
}
