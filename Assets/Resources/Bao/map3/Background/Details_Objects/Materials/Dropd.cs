using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropd : MonoBehaviour
{
    private Inventory inventory;
    public int i;


    private void Start()
    {
        inventory= GameObject.FindGameObjectWithTag("Playered").GetComponent<Inventory>();
    }

    private void Update()
    {
        if(transform.childCount <= 0)
        {
            inventory.isFull[i] = false;    
        }
    }
    public void DropItem()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<slots>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
   
}
