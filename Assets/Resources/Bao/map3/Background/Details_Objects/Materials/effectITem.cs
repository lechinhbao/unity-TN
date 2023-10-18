using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effectITem : MonoBehaviour
{
    public GameObject effect;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
    public void use()
    {
        Instantiate(effect,player.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
