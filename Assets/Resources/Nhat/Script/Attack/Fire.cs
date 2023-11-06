using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    private bool isRight;
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void Update()
    {
        //Di chuyển đạn
        transform.Translate((isRight ? Vector3.right : Vector3.left) * Time.deltaTime * 5f);

    }
    public void setIsRight(bool isRight)
    {
        this.isRight = isRight;
    }
}

