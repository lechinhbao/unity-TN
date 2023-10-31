using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private float speedUp;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector3(speedUp, 0);
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Stone"))
        {
            speedUp = speedUp * 2.0f;
            rigidbody2D.velocity = new Vector3(speedUp, Mathf.Abs(speedUp));
        }
    }
    public void SetSpeed(float value)
    {
        speedUp = value;

    }
}
