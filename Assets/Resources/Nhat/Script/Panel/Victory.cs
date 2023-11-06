using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject victoryPanel;
    private bool isGamePaused = false;
    public Button restartButton;
    public Button continueButton;

    private void Start()
    {
        ResumeGame(); // Bắt đầu game chưa tạm dừng.

        // Gắn các hàm xử lý cho các nút tương ứng.
        restartButton.onClick.AddListener(RestartGame);
        continueButton.onClick.AddListener(ResumeGame);
    }
    public void RestartGame()
    {
        // Gọi hàm này khi bạn muốn khởi đầu lại trò chơi sau khi nhân vật chết.
        Time.timeScale = 1; // Đảm bảo rằng thời gian đang chạy bình thường.
        isGamePaused = false;
        victoryPanel.SetActive(false); // Ẩn Panel Pause.

        // Điều hướng đến màn hình chơi lại (thay đổi tên scene nếu cần).
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1; // Khôi phục thời gian về bình thường.
        isGamePaused = false;
        victoryPanel.SetActive(false); // Ẩn Panel Pause.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Victory")) // Kiểms tra xem đối tượng va chạm có tag "Player" hay không
        {
            Time.timeScale = 0; // Tạm dừng thời gian trong trò chơi.
            isGamePaused = true;
            victoryPanel.SetActive(true); // Hiển thị Panel Pause.
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Victory")) // Kiểm tra xem đối tượng va chạm có tag "Player" hay không
        {
            Time.timeScale = 0; // Tạm dừng thời gian trong trò chơi.
            isGamePaused = true;
            victoryPanel.SetActive(true); // Hiển thị Panel Pause.
        }
    }

}
