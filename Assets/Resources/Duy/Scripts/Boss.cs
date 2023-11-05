using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
   
    Transform target;
    public Transform borderCheck;

    public bool isRight, isLeft;
    public GameObject fireBall;
    private float timeSpawn;
    private float time;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        timeSpawn = 10;
        time = timeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.x > transform.position.x)
        {
            isRight = true;
            transform.localScale = new Vector2(1f, 1f);
        }
        else
        {
            isRight = false;
            transform.localScale = new Vector2(-1f, 1f);
        }

        time -= Time.deltaTime;
      
        if (time < 0)
        {
            Vector2 scale = transform.localScale;
            if (isRight == true)
            {
                time = timeSpawn;
                GameObject fb = Instantiate(fireBall);
                fb.transform.position = new Vector2(
                    
                    transform.position.x + (isRight ? 0.1f : - 0.1f),
                    transform.position.y
                  
                );
                fb.GetComponent<FireScript>().SetSpeed(
                   isRight ? 4 : -4
                );
            }
            else 
            {
                
                time = timeSpawn;
                GameObject fb = Instantiate(fireBall);
                fb.transform.position = new Vector2(
                  
                    transform.position.x + (isLeft ? 0.1f : -0.1f),
                    transform.position.y
                     
                );
                fb.GetComponent<FireScript>().SetSpeed(
                   isLeft ? 4 : -4
                );
            }
            
        }

    }
}


