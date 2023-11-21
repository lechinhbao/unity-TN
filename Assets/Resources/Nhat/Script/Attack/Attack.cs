using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
        private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) // Người chơi đánh chiêu
        {
            animator.SetTrigger("IsAttack");
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            // Tắt animation chém khi ngừng nhấn "S"
            animator.ResetTrigger("IsAttack");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            // Kích hoạt animation chém khi nhấn "X"
            animator.SetTrigger("IsWalkAttack");
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            // Tắt animation chém khi ngừng nhấn "X"
            animator.ResetTrigger("IsWalkAttack");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Kích hoạt animation chém khi nhấn "X"
            animator.SetTrigger("IsRunAttack");
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            // Tắt animation chém khi ngừng nhấn "X"
            animator.ResetTrigger("IsRunAttack");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Kích hoạt animation chém khi nhấn "X"
            animator.SetTrigger("IsBullet");
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            // Tắt animation chém khi ngừng nhấn "X"
            animator.ResetTrigger("IsBullet");
        }
    }
}











