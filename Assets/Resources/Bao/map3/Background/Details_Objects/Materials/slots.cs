using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slots : MonoBehaviour
{
    public GameObject item;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Playered").transform;
    }

    
    public void SpawnDroppedItem()
    {
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Instantiate(item, playerPos, Quaternion.identity);
    }

}
