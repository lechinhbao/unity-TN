using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool isRight;

    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        //Di chuyển đạn
        transform.Translate((isRight ? Vector3.right : Vector3.left) * Time.deltaTime * 5f);

        // Xoay mặt viên đạn theo hướng của người chơi
     

    }

    public void setIsRight(bool isRight)
    {
        this.isRight = isRight;
     
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Monster"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Stone"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(gameObject);
        }
    }
}

