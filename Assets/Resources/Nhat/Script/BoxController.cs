using System.Collections;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private bool isBoxActive = true;

    private void Start()
    {
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
        yield return new WaitForSeconds(10f); // Đợi 3 giây
    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
        
            // Kiểm tra va chạm với mặt đất (hoặc các platform)
            if (collision.gameObject.CompareTag("Stone"))
            {
                Destroy(gameObject); // Xóa đối tượng box
            }
        }
    }