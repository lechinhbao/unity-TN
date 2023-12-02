using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Skill1 : MonoBehaviour
{
    public Image imageCooldown;
    public TMP_Text textCooldown;
    public float cooldown = 3;
    private bool isCooldown;

    void Start()
    {
        textCooldown.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isCooldown)
        {
            StartCoroutine(StartCooldown());
        }

        if (isCooldown)
        {
            imageCooldown.fillAmount += 1 / cooldown * Time.deltaTime;

            if (imageCooldown.fillAmount >= 1)
            {
                imageCooldown.fillAmount = 0;
                isCooldown = false;
                textCooldown.text = "";
            }
            else
            {
                int remainingSeconds = Mathf.CeilToInt((1 - imageCooldown.fillAmount) * cooldown);
                textCooldown.text = remainingSeconds.ToString();
            }
        }
    }

    IEnumerator StartCooldown()
    {
        isCooldown = true;
        Debug.Log("Wait for " + cooldown + " seconds to cooldown.");

        float remainingTime = cooldown;
        while (remainingTime > 0)
        {
            textCooldown.text = Mathf.CeilToInt(remainingTime).ToString();
            yield return new WaitForSeconds(1f);
            remainingTime -= 1f;
        }

        textCooldown.text = "";
        isCooldown = false;
        Debug.Log("Cooldown complete!");
    }
}
