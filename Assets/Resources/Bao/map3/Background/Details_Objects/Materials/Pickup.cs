using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
   private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Playered").GetComponent<Inventory>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Playered"))
        {
            
            for(int i =0; i<inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    Debug.Log("dd");
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);
                    break;
                }
                
            }
        }
    }
}
