using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    public float delayTime = 5.0f;
    public string animationTriggerName = "Idle"; // Đặt tên trigger cho animation "Idle" trong Animator của bạn.

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
