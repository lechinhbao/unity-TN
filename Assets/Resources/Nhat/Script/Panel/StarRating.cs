using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarRating : MonoBehaviour
{
    public Image starPrefab;
    public Transform starContainer;
    public TextMeshPro scoreText;

    private int currentScore = 0;
    private int maxScore = 5; // Số sao tối đa

    void Start()
    {
        InitializeStars();
        UpdateScoreText();
    }

    void InitializeStars()
    {
        for (int i = 0; i < maxScore; i++)
        {
            Image star = Instantiate(starPrefab, starContainer);
            // Gắn một script để xử lý sự kiện click vào sao
            star.gameObject.AddComponent<StarClickHandler>().starRating = this;
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore + "/" + maxScore;
    }

    public void AddStar()
    {
        if (currentScore < maxScore)
        {
            currentScore++;
            UpdateScoreText();
        }
    }

    public void RemoveStar()
    {
        if (currentScore > 0)
        {
            currentScore--;
            UpdateScoreText();
        }
    }
}

public class StarClickHandler : MonoBehaviour, IPointerClickHandler
{
    public StarRating starRating;

    public void OnPointerClick(PointerEventData eventData)
    {
        // Gọi phương thức của StarRating khi một sao được click
        starRating.AddStar();
    }
}
