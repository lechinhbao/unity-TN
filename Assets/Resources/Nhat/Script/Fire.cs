using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab viên đạn
    public Transform firePoint; // Điểm bắn viên đạn

    public float bulletSpeed = 10f; // Tốc độ viên đạn

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Tạo một thể hiện của Prefab viên đạn tại vị trí của firePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Lấy Rigidbody2D của viên đạn để áp dụng lực
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Áp dụng lực để bắn viên đạn
        rb.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
    }
}

