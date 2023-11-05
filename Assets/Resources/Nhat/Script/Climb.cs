using UnityEngine;

public class Climb : MonoBehaviour
{
    public float climbSpeed = 2.0f;
    private bool isClimbing = false;

    void Update()
    {
        if (isClimbing)
        {
            // Xử lý việc nhân vật leo lên cây thang
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 climbDirection = new Vector3(0, verticalInput, 0) * climbSpeed * Time.deltaTime;
            transform.Translate(climbDirection);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder")) // Đảm bảo cây thang được đánh dấu với tag "Ladder"
        {
            isClimbing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder")) // Đảm bảo cây thang được đánh dấu với tag "Ladder"
        {
            isClimbing = false;
        }
    }
}
