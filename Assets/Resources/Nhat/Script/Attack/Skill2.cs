using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Skill2 : MonoBehaviour
{
    public Image imageCooldown;
    public float cooldown = 3;
    bool isCooldown;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isCooldown = true;
            Debug.Log("Đợi 3 giây để hồi chiêu");
        }
        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;

            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
