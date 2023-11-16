using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerD : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
   // private bool isRight = true;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 scale = transform.localScale;
        anim.SetBool("isRunning", false);
        if (Input.GetKey(KeyCode.RightArrow))
        {

           
            anim.SetBool("isRunning", true);
            scale.x = 1;
            transform.Translate(Vector3.right * 3f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {

           
            anim.SetBool("isRunning", true);
            scale.x = -1;
            transform.Translate(Vector3.left * 3f * Time.deltaTime);
        }
        transform.localScale = scale;

        
    }
}
