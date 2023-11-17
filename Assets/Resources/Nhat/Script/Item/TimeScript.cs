using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class TimeScript : MonoBehaviour
{
    //đếm thời gian chơi
    private int time; //Thời gian tính băng giây
    public TMP_Text timeText; //Hiển thị thời gian chơi
    private bool isAlive; //Kiểm tra nhân vật tương tác

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        time = 0;
        timeText.text = time + "s";
        StartCoroutine(UpdateTime());
    }
    IEnumerator UpdateTime()
    {
        while (isAlive)
        {
            time++;
            timeText.text = time + "s";
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
