using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDragon : MonoBehaviour
{
    public float left, right;
    public float speed;
    public bool isRight;
   public GameObject Player;
    public GameObject Fire;
    private float timeSpawn;// thoi gian tao vien dan
    private float time; // thoi gian dem
    // Start is called before the first frame update
    void Start()
    {
       timeSpawn = 3;
       time = timeSpawn;
    }
   

    // Update is called once per frame
    void Update()
    {
       Vector2 scale = transform.localScale;


        if (isRight)
        {
            scale.x = 1;
            transform.Translate(Vector3.right * 1f * Time.deltaTime);
        }
        else
        {
            scale.x = -1;
            transform.Translate(Vector3.left * 1f * Time.deltaTime);
        }
        transform.localScale = scale;

       time -= Time.deltaTime;
        if(time < 0)
        {
            time = timeSpawn;
            GameObject fb = Instantiate(Fire);
            fb.transform.position = new Vector2(
                transform.position.x + (isRight ? 0.1f : -0.1f),
                transform.position.y
            );
            fb.GetComponent<FireScript>().SetSpeed(
                isRight ? 4 : -4
            );
        }

        var positionBug = transform.position.x;

        if (Player != null )
        {
            var positionPlayer = Player.transform.position.x;
            if (positionPlayer > left && positionPlayer < right)
            {
                if (positionPlayer < positionBug)
                {
                    isRight = false;
                }

                if (positionPlayer > positionBug)
                {
                    isRight = true;
                }
            }

             if (positionBug < left)
        {
            isRight = true;
        }

        if(positionBug > right)
        {
            isRight = false;
        }
    }
}
 private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trai"))
        {
            isRight = isRight ? false : true;
        }
    }
}
