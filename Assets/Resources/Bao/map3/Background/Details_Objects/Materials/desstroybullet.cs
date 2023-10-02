using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desstroybullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime = 0.5f;
    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enimi"))
        {

            animator.SetBool("BOM", true);
            Destroy(gameObject,0.1f);
        }
    }
   
}
