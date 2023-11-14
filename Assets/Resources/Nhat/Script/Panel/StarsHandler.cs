using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsHandler : MonoBehaviour
{
    public GameObject[] stars;
    private int coinsCount;
    // Start is called before the first frame update
    void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("Coin").Length;

    }

    public void starsAcheived()
    {
        int coinsLeft = GameObject.FindGameObjectsWithTag("Coin").Length;
        int coinsCollected = coinsCount - coinsLeft;
        float percentage = float.Parse(coinsCollected.ToString()) / float.Parse(coinsCount.ToString());

        if (percentage >= 33f && percentage < 66)
        {
            //one star
            stars[0].SetActive(true);
        }
        else if (percentage >= 66 && percentage < 70)
        {
            //Tow star
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else
        {
            //three star
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }
}
