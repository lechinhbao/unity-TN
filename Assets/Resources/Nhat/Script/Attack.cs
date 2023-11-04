using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
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
            animator.SetTrigger("IsAttack");
            // isAttacking = true;        
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            // Tắt animation chém khi ngừng nhấn "S"
            animator.ResetTrigger("IsAttack");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            // Kích hoạt animation chém khi nhấn "X"
            animator.SetTrigger("IsAttackExtra");
        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            // Tắt animation chém khi ngừng nhấn "X"
            animator.ResetTrigger("IsAttackExtra");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {   
            // Kích hoạt animation chém khi nhấn "X"
                animator.SetTrigger("IsRunAttack");           
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            // Tắt animation chém khi ngừng nhấn "X"
            animator.ResetTrigger("IsRunAttack");
        }
        }
    }
 

  








