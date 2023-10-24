using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Transform target;
    public Transform borderCheck; 
    
    public bool isRight;
    // public bool isShootable = false;
    public GameObject fireBall;
    private float timeSpawn ;
    private float time ;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

       timeSpawn = 20;
       time = timeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(1f, 1f);
        }else
        {
            transform.localScale = new Vector2(-1f, 1f);

        }

        time -= Time.deltaTime;
        if(time < 0)
        {
            time = timeSpawn;
            GameObject fb = Instantiate(fireBall);
            fb.transform.position = new Vector2(
                transform.position.x + (isRight ? 0.8f : -0.8f),
                transform.position.y
            );
            fb.GetComponent<FireScript>().SetSpeed(
                isRight ? 2 : -2
            );
        }
    }

   
   
}
