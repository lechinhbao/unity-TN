using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIhandler : MonoBehaviour
{
    public GameObject LevelDialog;
    public TMP_Text LevelStatus;
    public TMP_Text scoreText;

    public static UIhandler instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    public void ShowLevelDialog(string status, string scores)
    {
        GetComponent<StarsHandler>().starsAcheived();
        LevelDialog.SetActive(true);
        LevelStatus.text = status;
        scoreText.text = scores;
    }
}
