using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPET : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    private Transform target;
    private Vector3 originalScale ; // Lưu trữ tỷ lệ ban đầu của pet

    

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        originalScale = transform.localScale; // Lưu trữ tỷ lệ ban đầu của pet
    }

    void Update()
    {
      



        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            // Di chuyển pet
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Xác định hướng di chuyển (trái hoặc phải)
            float moveDirection = Mathf.Sign(target.position.x - transform.position.x);

            // Đặt tỷ lệ theo hướng di chuyển
            Vector3 newScale = originalScale;
            newScale.x = Mathf.Abs(newScale.x) * moveDirection; // Đảm bảo tỷ lệ không bị âm

            // Áp dụng tỷ lệ vào pet
            transform.localScale = newScale;
        }
    }
   
}
