using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trapblock : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    //block
    private bool block = false;
    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            block = true;
            animator.SetBool("block", true);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            block = false;
            animator.SetBool("block", false);
        }
    }
}
