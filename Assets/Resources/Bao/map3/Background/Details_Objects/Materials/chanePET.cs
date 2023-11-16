using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chanePET : MonoBehaviour
{
    public GameObject[] playerPerfabs;
    int characterIndex;
    public static Vector2 DHS = new Vector2(4, 2);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {

       characterIndex = PlayerPrefs.GetInt("selectCharacter", 0);
        Instantiate(playerPerfabs[characterIndex] ,DHS,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
