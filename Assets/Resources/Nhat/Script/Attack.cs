using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
   // public int attackDamage = 20;
   // public float attackRange = 2.0f;
  
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Kích hoạt animation chém khi nhấn "S"
            animator.SetTrigger("Attack");
         //   isAttacking = true;
        
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            // Tắt animation chém khi ngừng nhấn "S"
            animator.ResetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Kích hoạt animation chém khi nhấn "X"
            animator.SetTrigger("PlayerAttackExtra");
            //   isAttacking = true;

        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            // Tắt animation chém khi ngừng nhấn "X"
            animator.ResetTrigger("PlayerAttackExtra");
        }
        
    }
 
}
  








