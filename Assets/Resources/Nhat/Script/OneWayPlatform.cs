using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Diagnostics;

public class OneWayPlatform : MonoBehaviour
{
    PlayerControlsSimple playerControls;
    PlatformEffector2D platformEffector;

    private void Awake()
    {
        platformEffector = GetComponent<PlatformEffector2D>();        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            playerControls = collision.gameObject.GetComponent<PlayerControlsSimple>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (playerControls == null)
            return;
        if (playerControls.fallThrough)
        {
            platformEffector.rotationalOffset = 180;
            playerControls = null;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        playerControls = null;
        platformEffector.rotationalOffset = 0;
    }
}
