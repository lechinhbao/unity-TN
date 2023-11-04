using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    public Button restartButton;
    public Button continueButton;
    public Button exitButton;

    private bool isGamePaused = false;

    void Start()
    {
        ResumeGame(); // Bắt đầu game chưa tạm dừng.

        // Gắn các hàm xử lý cho các nút tương ứng.
        restartButton.onClick.AddListener(RestartGame);
        continueButton.onClick.AddListener(ResumeGame);
        exitButton.onClick.AddListener(ExitGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isGamePaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.P) && isGamePaused)
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0; // Tạm dừng thời gian trong trò chơi.
        isGamePaused = true;
        pausePanel.SetActive(true); // Hiển thị Panel Pause.
    }

    public void ResumeGame()
    {
<<<<<<< HEAD:Assets/Resources/Nhat/Script/Pause.cs
        Time.timeScale = 1; // Khôi phục thời gian về bình thường.
=======
       Time.timeScale = 1; // Khôi phục thời gian về bình thường.
>>>>>>> Vien:Assets/Resources/Image/vien/cript/Pause.cs
        isGamePaused = false;
        pausePanel.SetActive(false); // Ẩn Panel Pause.
    }

    public void RestartGame()
    {
        // Gọi hàm này khi bạn muốn khởi đầu lại trò chơi sau khi nhân vật chết.
<<<<<<< HEAD:Assets/Resources/Nhat/Script/Pause.cs
        Time.timeScale = 1; // Đảm bảo rằng thời gian đang chạy bình thường.
=======
      //  Time.timeScale = 1; // Đảm bảo rằng thời gian đang chạy bình thường.
>>>>>>> Vien:Assets/Resources/Image/vien/cript/Pause.cs
        isGamePaused = false;
        pausePanel.SetActive(false); // Ẩn Panel Pause.

        // Điều hướng đến màn hình chơi lại (thay đổi tên scene nếu cần).
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        // Thoát game (chỉ hoạt động trong build độc lập).
        Application.Quit();
    }
}
