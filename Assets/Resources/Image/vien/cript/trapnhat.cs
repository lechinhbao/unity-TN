using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class trapnhat : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    //block
    private bool blocknhat = false;
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
            blocknhat = true;
            animator.SetBool("blocknhat", true);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            blocknhat = false;
            animator.SetBool("blocknhat", false);
        }
    }
}
