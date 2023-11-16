using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaoRun : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D coli;
    private SpriteRenderer sprite;


    private float dirX = 0f;
    [SerializeField] float moveSpeedB = 3f;
    [SerializeField] float JumForceB = 4f;
    [SerializeField] private LayerMask jumpableGround;

    private enum MovemenState {idle, running,jumping,falling }

    private bool isRight= true;
   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coli = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

    }


    // Update is called once per frame
    private void Update()
    {
        anim.SetBool("fire", false);


        if (Input.GetKeyDown(KeyCode.K))
        {
            anim.SetBool("fire",true);
            var x = transform.position.x + (isRight ? 0.5f : - 0.5f);
            var y = transform.position.y -0.1f;
            var z = transform.position.z;
           GameObject gameObject= (GameObject) Instantiate(
                Resources.Load("Bao/refabs/bulletPlayer"), new Vector3(x,y,z),
                Quaternion.identity
             );
            gameObject.GetComponent<BulletPlayerB>().setIsRoght(isRight);
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            isRight = false;
            Debug.Log("da quay");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            isRight = true;
        }


        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeedB, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumForceB);
        }
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {

        MovemenState state;

        if (dirX > 0f)
        {
            state = MovemenState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovemenState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovemenState.idle;
        }
        if(rb.velocity.y > .1f)
        {
            state = MovemenState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovemenState.falling;
        }


        anim.SetInteger("state",(int)state);
    }

    private bool IsGround()
    {
       return Physics2D.BoxCast(coli.bounds.center, coli.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enimi")
        {
            anim.SetTrigger("hurt");
        }
        
    }
}
