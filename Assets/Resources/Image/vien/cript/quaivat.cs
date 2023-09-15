using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quaivat : MonoBehaviour
{
    public float start, end;
    private bool isRight; //check
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //vi tri cua quaivat
        var positionBug = transform.position.x;

        //quai vat di theo
        if (player != null)
        {
            var positionplayer = player.transform.position.x;
            if (positionplayer > start && positionplayer < end)
            {
                if (positionplayer < positionBug) isRight = false;
                if (positionplayer > positionBug) isRight = true;
            }
        }

        if (positionBug < start)
        {
            isRight = true;
        }
        if (positionBug > end)
        {
            isRight = false;
        }

        Vector2 scale = transform.localScale;

        if (isRight)
        {
            //vector3
            scale.x = 1;
            transform.Translate(Vector3.right * 2f * Time.deltaTime);
        }
        else
        {
            scale.x = -1;
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
        }
        transform.localScale = scale;
    }
    public void OnTriggerEnter2D(Collider2D collider)
    {
        //cham quay dau
        if (collider.gameObject.tag == "trai")
        {
            isRight = isRight ? false : true;
        }
    }
    public void SetStart(float start)
    {
        this.start = start;
    }

    public void SetEnd(float end)
    {
        this.end = end;
    }

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
}
