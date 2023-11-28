/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : StateMachineBehaviour
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
        if(target == null)
        {

            return;
        }
        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
            return;

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 4)
            animator.SetBool("IsWalk", true);
   
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdle : StateMachineBehaviour
{
    Transform target;
    Transform borderCheck;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        UpdateTargetReference(animator);
        borderCheck = animator.GetComponent<Boss>().borderCheck;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (target == null)
        {
            // Player is not found, perform some action (e.g., return to idle state)
            animator.SetBool("IsWalk", false);
            return;
        }

        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
        {
            // Handle border check logic
            return;
        }

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 4)
        {
            // Player is within a certain distance, start walking
            animator.SetBool("IsWalk", true);
        }
        else
        {
            // Player is not within distance, perform some other action
            animator.SetBool("IsWalk", false);
        }
    }

    // Update the reference to the player target
    void UpdateTargetReference(Animator animator)
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            target = playerObject.transform;
        }
    }
}
