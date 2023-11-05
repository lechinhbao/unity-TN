using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelDie : MonoBehaviour
{
    private bool isGameDie = false;
    public GameObject panelDie;
    public Button continueButton;
    public Button restartButton;
    // Start is called before the first frame update
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
        isGameDie = false;
        panelDie.SetActive(false); // Ẩn Panel Pause.

        // Điều hướng đến màn hình chơi lại (thay đổi tên scene nếu cần).
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1; // Khôi phục thời gian về bình thường.
        isGameDie = false;
        panelDie.SetActive(false); // Ẩn Panel Pause.
    }


}

