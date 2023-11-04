using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class mana2 : MonoBehaviour
{
    public Image fillBar;

    public void UpdateMana(int currentValue, int maxValue)
    {
        fillBar.fillAmount = (float)currentValue / (float)maxValue;
    }
}
