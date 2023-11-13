using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour
{
    public TMP_Text scoreText;

    private int currentScore = 0;

    void Start()
    {
        // Đọc điểm từ PlayerPrefs khi bắt đầu game
        LoadScore();
        UpdateUI();
    }

    void UpdateUI()
    {
        // Cập nhật UI với điểm hiện tại
        scoreText.text = $"Score: {currentScore}";
    }

    public void IncreaseScore(int amount)
    {
        // Tăng điểm khi có sự kiện xảy ra (ví dụ: người chơi thu thập điểm)
        currentScore += amount;

        // Cập nhật UI
        UpdateUI();

        // Lưu dữ liệu vào PlayerPrefs
        SaveScoreCoin();
    }

    void SaveScoreCoin()
    {
        // Lưu điểm vào PlayerPrefs
        PlayerPrefs.SetInt("CurrentScore", currentScore);
        PlayerPrefs.Save();
    }

    void LoadScore()
    {
        // Đọc điểm từ PlayerPrefs
        currentScore = PlayerPrefs.GetInt("CurrentScore", 0);
    }
}
