using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Button[] button;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < button.Length; i++)
        {
            button[i].interactable = false;
        }
        for (int i = 0;i < unlockedLevel; i++) 
        {
            button[i].interactable = true;
        }
    }

    public void Selectlevel(int LevelId)
    {
        string LeveName = "Level " + LevelId;
        SceneManager.LoadScene(LeveName);
    }
}
