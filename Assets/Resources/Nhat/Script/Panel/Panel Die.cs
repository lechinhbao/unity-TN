using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PanelDie : MonoBehaviour
{
    private bool isGameDie = false;
    public GameObject panelDie;
    public Button continueButton;
    public Button restartButton;

    private int coinsCollected = 0;      // Số xu đã ăn
    public TMP_Text coinText;               // Text để hiển thị số xu

    private int star = 0;            // Số sao
    public TMP_Text starText;            // Text để hiển thị số sao

    private int time; //Thời gian tính băng giây
    public TMP_Text timeText; //Hiển thị thời gian chơi
    private bool isAlive; //Kiểm tra nhân vật tương tác
    private void Start()
    {
        ResumeGame(); // Bắt đầu game chưa tạm dừng.

        // Gắn các hàm xử lý cho các nút tương ứng.
        restartButton.onClick.AddListener(RestartGame);
        continueButton.onClick.AddListener(ResumeGame);

        UpdateCoins();  // Cập nhật số xu khi bắt đầu

        //Time
        isAlive = true;
        time = 0;
        timeText.text = time + "s";
        StartCoroutine(UpdateTime());

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

    void UpdateCoins()
    {
        coinText.text = "Coins: " + coinsCollected.ToString();  // Cập nhật số xu trong Text
        starText.text = "Stars: " + star.ToString();           // Cập nhật số sao trong Text
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coinsCollected += 1;
            coinText.text = coinsCollected + "Score:";
            Destroy(collision.gameObject);
            star += 10;              // Cộng 10 sao mỗi khi ăn 1 xu
            UpdateCoins();            // Cập nhật số xu
        }
    }
    //Time
    IEnumerator UpdateTime()
    {
        while (isAlive)
        {
            time++;
            timeText.text = time + "s";
            yield return new WaitForSeconds(1);
        }
    }

}

