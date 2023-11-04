using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dan : MonoBehaviour
{

    // Tốc độ của viên đạn
    public float speed = 100;

    // Hàm được gọi khi viên đạn được bắn
    void OnEnable()
    {
        // Đặt tốc độ cho viên đạn
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
    }

    // Hàm được gọi khi viên đạn va chạm với một vật thể khác
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Nếu viên đạn đã chạm đất, thì phá hủy nó
        if (collision.gameObject.tag == "Stone")
        {
            Destroy(gameObject);
        }
    }
}


