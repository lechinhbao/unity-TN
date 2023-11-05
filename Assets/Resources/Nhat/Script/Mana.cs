using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public Image fillBar;

    public void UpdateMana(int currentValue, int maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
    }
}
