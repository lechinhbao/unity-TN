using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danlav : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.up * speed; // Đã sửa
    }

    // Update is called once per frame
    void Update()
    {

    }
}
