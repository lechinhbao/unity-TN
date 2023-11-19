using System.Collections;
using UnityEngine;

public class HoiChieu : MonoBehaviour
{
    public float cooldownTime = 5f; // Thời gian hồi chiêu
    private bool isCooldown = false;
    private float cooldownTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra nếu đang trong thời gian cooldown
        if (isCooldown)
        {
            // Cập nhật thời gian cooldown
            cooldownTimer -= Time.deltaTime;

            // Kiểm tra nếu cooldown đã kết thúc
            if (cooldownTimer <= 0)
            {
                isCooldown = false;
            }
        }

        // Kích hoạt hồi chiêu (ví dụ: bằng cách nhấn phím hoặc sử dụng một sự kiện khác)
        if (Input.GetKeyDown(KeyCode.R) && !isCooldown)
        {
            ActivateSkill();
        }
    }

    // Hàm kích hoạt hồi chiêu
    void ActivateSkill()
    {
        // Thực hiện các hành động hồi chiêu ở đây
        Debug.Log("Skill activated!");

        // Bắt đầu thời gian cooldown
        isCooldown = true;
        cooldownTimer = cooldownTime;

        // Thực hiện hiệu ứng xoay
        StartCoroutine(RotateOverTime(1f));
    }

    // Coroutine để thực hiện xoay
    IEnumerator RotateOverTime(float duration)
    {
        float elapsed = 0f;
        float startRotation = transform.rotation.eulerAngles.z;
        float endRotation = startRotation + 360f;

        while (elapsed < duration)
        {
            float newRotation = Mathf.Lerp(startRotation, endRotation, elapsed / duration);
            transform.rotation = Quaternion.Euler(0, 0, newRotation);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.rotation = Quaternion.Euler(0, 0, endRotation); // Đảm bảo hoàn thành xoay
    }
}
