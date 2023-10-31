using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
     private new Rigidbody2D rigidbody2D;
    private float speedUp;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(speedUp, 0);
        Destroy(gameObject, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.CompareTag("block"))
        // {   
        //     speedUp = speedUp * 0.95f  ;
        //     rigidbody2D.velocity = new Vector2(speedUp, Mathf.Abs(speedUp));
        // }
    }

    public void SetSpeed(float value)
    {
        speedUp = value;  
    }
}
