using System.Collections;
using UnityEngine;

public class lighting : MonoBehaviour
{
    private Animator animator;
    public float delayTime = 1.3f;
    public string animationTriggerName = "lightning"; // Đặt tên trigger cho animation "Idle" trong Animator của bạn.

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnimationRepeatedly());
    }

    IEnumerator PlayAnimationRepeatedly()
    {
        while (true)
        {
            yield return new WaitForSeconds(delayTime);
            animator.SetTrigger(animationTriggerName);
        }
    }
}