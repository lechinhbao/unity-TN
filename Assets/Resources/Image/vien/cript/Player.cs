using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.Networking;

public class Player3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isFloor;
    private Animator anim;
    public GameObject menu;
    private bool isPlaying = true;
    // private int countCoin = 0;
    public TMP_Text txtCoin;
    //Nhạc
    public AudioSource soundCoin;
    private bool isRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //Load điểm, load vị trí
        /*  if (LoginUser.loginResponse.score >= 0)
          {
              countCoin = LoginUser.loginResponse.score;
              txtCoin.text = countCoin + " x";
          }

          if (LoginUser.loginResponse.positionX != "")
          {
              var posX = float.Parse(LoginUser.loginResponse.positionX);
              var posY = float.Parse(LoginUser.loginResponse.positionY);
              var posZ = float.Parse(LoginUser.loginResponse.positionZ);
              transform.position = new Vector3(posX, posY, posZ);
          }*/

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 scale = transform.localScale;
        //   anim.SetBool("isRunning", false);

        //Người dùng nhấn mũi tên bên phải

        if (Input.GetKey(KeyCode.RightArrow))
        {
            isRight = true;

            anim.SetBool("isRunning", true);
            scale.x = 1;
            //Vector3(1,0,0)
        //   transform.Translate(Vector3.right * 5f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            isRight = false;

            anim.SetBool("isRunning", true);
            scale.x = -1;
            //Vector3(1,0,0)
          //  transform.Translate(Vector3.left * 5f * Time.deltaTime);
        }

        transform.localScale = scale;

        if (Input.GetKey(KeyCode.Space))
        {
            if (isFloor)
            {
                //Vector3(1,0,0)
                //transform.Translate(Vector3.up * 10f * Time.deltaTime);
                rb.AddForce(new Vector2(0, 400));
                isFloor = false;
            }
        }
        //Getkey: nhấn giữ nút
        //GetKeyDown: Nhấn phím 1 lần
        //GetKeyUp

        //Show menu
        if (Input.GetKeyDown(KeyCode.P))
        {
            showMenu();
        }
        //Ban dan
        if (Input.GetKeyDown(KeyCode.S))
        {

            var x = transform.position.x + (isRight ? 0.5f : -0.5f);
            var y = transform.position.y;
            var z = transform.position.z;

            GameObject gameObject = (GameObject)Instantiate(
                Resources.Load("Prefabs/bullet"),
                new Vector3(x, y, z),
                Quaternion.identity
                );
            //gameObject.GetComponent<Bullet>().setIsRight(isRight);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = true;
        }
    }

    public void showMenu()
    {
        if (isPlaying)
        {

            menu.SetActive(true);
       //     Time.timeScale = 0;
            isPlaying = false;
        }
        else
        {
            menu.SetActive(false);
        //    Time.timeScale = 1;
            isPlaying = true;
        }
    }
}
