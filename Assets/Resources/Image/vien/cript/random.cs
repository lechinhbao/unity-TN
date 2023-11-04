using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{

    // Tạo một prefab cho viên đạn
    public GameObject bulletPrefab;

    // Tạo một hàm để bắn đạn
    public void Shoot()
    {
        // Tạo một đối tượng mới của viên đạn
        GameObject bullet = Instantiate(bulletPrefab);

        // Đặt vị trí của viên đạn ở phía trên đối tượng bắn
        Vector3 position = transform.position;
        position.y += 100;
        bullet.transform.position = position;

        // Cho viên đạn rơi xuống
        bullet.GetComponent<Rigidbody2D>().gravityScale = 1;

        // Thêm một script cho viên đạn
        bullet.AddComponent<Bullet>();
    }
}
