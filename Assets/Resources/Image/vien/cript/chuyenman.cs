using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class chuyenman : MonoBehaviour
{
     public Button Button;
    public void Menu()
    {
        SceneManager.LoadScene(2);
    }

    public void vien()
    {
        SceneManager.LoadScene(3);
    }
    public void nhat()
    {
        SceneManager.LoadScene(4);
    }
    public void khoi()
    {
        SceneManager.LoadScene(5);
    }
    public void bao()
    {
        SceneManager.LoadScene(6);
    }
    public void duy()
    {
        SceneManager.LoadScene(7);
    }
}