using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{

    private int coinsCollected = 0;      // Số xu đã ăn
    public TMP_Text coinText;               // Text để hiển thị số xu


    public GameObject[] stars;          // Mảng chứa các sao (đặt trong Inspector)
    public int[] starThresholds;         // Ngưỡng số xu để bật mỗi sao

    private int star = 0;            // Số sao
    public TMP_Text starText;            // Text để hiển thị số sao

    void Start()
    {
        UpdateCoins();  // Cập nhật số xu khi bắt đầu
        ActivateStars();  // Kích hoạt sao dựa trên số xu đã ăn được
    }

    void UpdateCoins()
    {
        coinText.text = "Coins: " + coinsCollected.ToString();  // Cập nhật số xu trong Text
        starText.text = "Stars: " + star.ToString();           // Cập nhật số sao trong Text
    }

    void ActivateStars()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (star >= starThresholds[i])
            {
                stars[i].SetActive(true);  // Kích hoạt sao nếu số xu đạt ngưỡng
            }
        }
    }
   
// Hàm này có thể được gọi khi nhân vật ăn một số xu (tùy thuộc vào game logic)
/*    public void CollectCoin(int amount)
    {
        coinsCollected += amount;  // Tăng số xu đã ăn
        UpdateCoins();            // Cập nhật số xu
        ActivateStars();          // Kích hoạt sao tương ứng
    }*/
private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            coinsCollected += 1;
            coinText.text = coinsCollected + "Score:";
            Destroy(collision.gameObject);
            star += 10;              // Cộng 10 sao mỗi khi ăn 1 xu
            UpdateCoins();            // Cập nhật số xu
            ActivateStars();          // Kích hoạt sao tương ứng
        }
    }
}
