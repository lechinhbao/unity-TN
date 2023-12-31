using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManaer : MonoBehaviour
{
    public GameObject[] playerPerfabs;
    int characterIndex;
    public static Vector2 DHS = new Vector2(4, 2);

    private void Awake()
    {
        characterIndex = PlayerPrefs.GetInt("selectCharacter", 0);
        Instantiate(playerPerfabs[characterIndex], DHS, Quaternion.identity);
    }
}
