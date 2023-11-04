using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Playertelepor : MonoBehaviour
{

    private GameObject currentteleporter;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(currentteleporter != null)
            {
                transform.position = currentteleporter.GetComponent<Telepor>().GetDestination().position;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentteleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Telleporter"))
        {
            if(collision.gameObject == currentteleporter)
            {
                currentteleporter = null;
            }
        }
    }
}
