using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    void Update()
    {
        //Bắn đạn
        if (Input.GetKeyDown(KeyCode.S))
        {
            var x = transform.position.x;
            var y = transform.position.y;
            var z = transform.position.z;

            Instantiate(
                Resources.Load("Nhat/Prefabs/Fire"),
                new Vector3(x, y, z),
                Quaternion.identity
                );
        }
    }

}

