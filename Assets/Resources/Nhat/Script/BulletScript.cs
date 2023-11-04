using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Animator animator;
    // public int attackDamage = 20;
    // public float attackRange = 2.0f;
    private bool isRight = true;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            //Bắn đạn
            var x = transform.position.x + (isRight ? 0.5f : -0.5f);
            var y = transform.position.y;
            var z = transform.position.z;

            GameObject gameObject = (GameObject) Instantiate(
            Resources.Load("Nhat/Prefabs/Fire"),
            new Vector3(x, y, z),
            Quaternion.identity

            );
           // gameObject.GetComponent<Fire>().setIsRight(isRight);

            // Kích hoạt animation chém khi nhấn "S"
            animator.SetTrigger("IsAttack");
            //   isAttacking = true;        
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
            //   isAttacking = true;

        }
        else if (Input.GetKeyUp(KeyCode.X))
        {
            // Tắt animation chém khi ngừng nhấn "X"
            animator.ResetTrigger("IsAttackExtra");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            {
                // Kích hoạt animation chém khi nhấn "X"
                animator.SetTrigger("PlayerRunAttack");
                // isAttacking = true;
            }

        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            // Tắt animation chém khi ngừng nhấn "X"
            animator.ResetTrigger("PlayerRunAttack");
        }
    }
}











