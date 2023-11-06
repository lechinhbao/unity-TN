using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera2 : MonoBehaviour
{
    public float left, right;
    public GameObject knight;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        var knightX = knight.transform.position.x;
        var knightY = knight.transform.position.y;

        var cameraX = transform.position.x;
        var cameraY = transform.position.y;

        if (knightX > left && knightX < right)
        {
            cameraX = knightX;
        }
        else
        {
            if (cameraX < left) cameraX = left;
            if (cameraX > right) cameraX = right;
        }
        if (knightY > 0)
        {
            cameraY = knightY;
        }
        else
        {
            cameraY = 0;
        }

        transform.position = new Vector3(cameraX, cameraY, -8);
    }

}
