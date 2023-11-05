using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer aMixer;
    public void ChangeValue(Slider slider)
    {
        switch (slider.value)
        {
            case 0:
                aMixer.SetFloat("volume", 0);
                break;
            case 1:
                aMixer.SetFloat("volume", -20);
                break;
            case 2:
                aMixer.SetFloat("volume", -40);
                break;
            case 3:
                aMixer.SetFloat("volume", -60);
                break;
            case 4:
                aMixer.SetFloat("volume", -80);
                break;
        }
    }
}
