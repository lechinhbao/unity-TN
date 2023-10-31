using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sung : MonoBehaviour
{

    public float left, right;
    public float speed;
    public bool isRight;

    public GameObject bossFireBall;
    private float timeSpawn; // thoi gian tao 1 vien dan
    private float time; // thoi gian dem

    // Start is called before the first frame update
    void Start()
    {
        timeSpawn = 1;
        time = timeSpawn;
    }

    // Update is called once per frame
    void Update()
    {

        float positionX = transform.localPosition.x;
        if (positionX < left)
        {
            //quay lại phải
            isRight = true;
        }
        else if (positionX > right)
        {
            //quay lại trái
            isRight = false;
        }
        Vector3 vector3;
        //xoay mặt qua phải.

        if (isRight)
        {
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? -1 : 1;
            transform.localScale = scale;

            vector3 = new Vector3(1, 0, 0);

        }
        else
        {
            //xoay mặt qua Trái.
            Vector2 scale = transform.localScale;
            scale.x *= scale.x > 0 ? 1 : -1;
            transform.localScale = scale;


            vector3 = new Vector3(-1, 0, 0);

        }
        //transform.Translate(vector3 * speed * Time.deltaTime);

        time -= Time.deltaTime;
        if (time < 0)
        {
            time = timeSpawn;
            GameObject fb = Instantiate(bossFireBall);
            fb.transform.position = new Vector2(
                transform.position.x + (isRight ? 0.8f : -0.8f),
                transform.position.y
                );
            fb.GetComponent<fireball>().SetSpeed(
                    isRight ? 10 : -10
                );
        }

    }
}