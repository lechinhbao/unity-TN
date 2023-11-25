using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossScript1 : StateMachineBehaviour
{
    Transform target;
    Transform borderCheck;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        borderCheck = animator.GetComponent<Boss>().borderCheck;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
            return;

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 4 )
         animator.SetBool("IsWalk",true);

        // Kiểm tra xem enemy có chạm vào player không
        Collider[] hitColliders = Physics.OverlapSphere(animator.transform.position, 1.0f);
        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Bật animation "Hurt"
                animator.SetBool("Hurt", true);
                //break; // Chỉ cần kích hoạt một lần khi chạm vào player
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
