using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float left, right;
    public GameObject baovemon;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (baovemon == null) return;
        var baovemonX = baovemon.transform.position.x;
        var baovemonY = baovemon.transform.position.y;

        var cameraX = transform.position.x;
        var cameraY = transform.position.y;

        if (baovemonX > left && baovemonX < right)
        {
            cameraX = baovemonX;
        }
        else
        {
            if (cameraX < left) cameraX = left;
            if (cameraX > right) cameraX = right;
        }
        cameraY = Mathf.Max(baovemonY, -2.52f);
        transform.position = new Vector3(cameraX, cameraY, -10);
    }
}
