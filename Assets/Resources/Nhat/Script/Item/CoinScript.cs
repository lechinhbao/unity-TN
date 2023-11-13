using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    // Start is called before the first frame update

    //Coin
    public TMP_Text txtCoin;
    private int countCoin = 0;

    //Popup
    public GameObject popUpCoin;
    public TMP_Text popUpCoinText;

  
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Coin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            //soundCoin.Play();
            countCoin += 1;
            txtCoin.text = countCoin + "";
            Destroy(collision.gameObject);

            //Popup
            popUpCoinText.text = countCoin.ToString();
            Instantiate(popUpCoin, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.tag == "checkpoint")
        {
               //SavePosition();
        }
    }

}
