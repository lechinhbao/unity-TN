using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    private int comboCount = 0;
    private Animator animator;
    private bool isComboActive = false;

    public int comboThreshold = 3; // Số lần đánh cần để kích hoạt combo
    public float comboDuration = 3.0f; // Thời gian tồn tại của combo animation

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) // Người chơi đánh chiêu
        {
            animator.SetTrigger("IsAttack");
            comboCount++;
            if (comboCount >= comboThreshold && !isComboActive)
            {
                StartCombo();
            }
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            // Tắt animation chém khi ngừng nhấn "S"
            animator.ResetTrigger("IsAttack");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Kích hoạt animation chém khi nhấn "X"
            animator.SetTrigger("IsRunAttack");
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            // Tắt animation chém khi ngừng nhấn "X"
            animator.ResetTrigger("IsRunAttack");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Kích hoạt animation chém khi nhấn "X"
            animator.SetTrigger("IsWalkAttack");
        }
        else if (Input.GetKeyUp(KeyCode.F))
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
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            animator.SetTrigger("IsPush");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.ResetTrigger("IsPush");
    }


    void StartCombo()
    {
        isComboActive = true;
        comboCount = 0;
        animator.SetBool("IsAttackExtra", true);
        StartCoroutine(EndCombo());
    }
    IEnumerator EndCombo()
    {
        yield return new WaitForSeconds(comboDuration);
        isComboActive = false;
        animator.SetBool("IsAttackExtra", false);
    }
}
