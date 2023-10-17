using UnityEngine;
using UnityEngine.UI;

public class Victory : MonoBehaviour
{
    public GameObject victoryPanel;
    private bool isGamePaused = false;
  
    public Button restartButton;
    public Button continueButton;
    private void Start()
    {
        victoryPanel.SetActive(false); // Ẩn victory panel ban đầu
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Kiểm tra xem đối tượng va chạm có tag "Player" hay không
        {
            Time.timeScale = 0; // Tạm dừng thời gian trong trò chơi.
            isGamePaused = true;
            victoryPanel.SetActive(true); // Hiển thị victory panel
        }
    }
}
