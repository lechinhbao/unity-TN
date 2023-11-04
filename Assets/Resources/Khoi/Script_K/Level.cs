using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Button button;
    
    public void levelr1()
    {
        SceneManager.LoadScene(3);
    }
    public void levelr2()
    {
        SceneManager.LoadScene(4);
    }
    public void levelr3()
    {
        SceneManager.LoadScene(5);
    }
    public void levelr4()
    {
        SceneManager.LoadScene(6);
    }
    public void levelr5()
    {
        SceneManager.LoadScene(7);
    }



}
