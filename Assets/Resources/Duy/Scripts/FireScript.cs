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
         if (collision.gameObject.CompareTag("Player"))
         {
            Destroy(gameObject);
         }
        if (collision.gameObject.CompareTag("Stone"))
        {
            Destroy(gameObject, 1f);
        }
    }

    public void SetSpeed(float value)
    {
        speedUp = value;  
    }
}
