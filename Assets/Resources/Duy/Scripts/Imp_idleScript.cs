using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imp_idleScript : MonoBehaviour
{
    public float start, end;
    private bool isRight;

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var positionEnemi = transform.position.x;
        if(positionEnemi <start)
        {
            isRight = true;
        }   
        if(positionEnemi > end)
        {
            isRight = false;

        }
        Vector2 scale = transform.localScale;
        if(isRight)
        {
            scale.x= 1;
            transform.Translate(Vector3.right * 1f * Time.deltaTime);
        }
        else
        {
            scale.x = -1;
            transform.Translate(Vector3.left * 1f * Time.deltaTime);
        }
        transform.localScale = scale;
       
    }
}
