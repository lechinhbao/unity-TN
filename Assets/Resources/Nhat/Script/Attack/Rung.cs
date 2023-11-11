using System.Collections;
using UnityEngine;

public class Rung : MonoBehaviour
{
    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có tag là "Player" hay không
        if (collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(Shake());
        }
    }

    private IEnumerator Shake()
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        // Đặt vị trí trở lại sau khi kết thúc rung
        transform.position = originalPosition;
    }
}
