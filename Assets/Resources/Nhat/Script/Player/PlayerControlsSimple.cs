using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControlsSimple : MonoBehaviour
{
    public bool fallThrough;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            fallThrough = true;
        }
        else
        {
            fallThrough = false;
        }
    }
}
