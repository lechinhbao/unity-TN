using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    public float intro_time = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Intro_for_intro());
    }

    IEnumerator Intro_for_intro()
    {
        yield return new WaitForSeconds(intro_time);
        SceneManager.LoadScene(1);
    }
}
