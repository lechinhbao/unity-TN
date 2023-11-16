using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helthB : MonoBehaviour
{
   private GameObject gameobject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Health()
    {
        Debug.Log(" da hoi mau");
        Destroy(gameobject);
    }
}
