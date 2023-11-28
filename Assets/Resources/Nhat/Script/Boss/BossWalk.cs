/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWalk : StateMachineBehaviour
{
    Transform target;

    public float speed = 1;
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
        Vector2 newPos = new Vector2(target.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, newPos, speed * Time.deltaTime);
        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
            animator.SetBool("IsWalk", false);

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 1.5)
            animator.SetBool("IsAttack", true);
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

public class BossWalk : StateMachineBehaviour
{
    Transform target;

    public float speed = 1;
    Transform borderCheck;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Attempt to find the player with the "Player" tag
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
        borderCheck = animator.GetComponent<Boss>().borderCheck;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Check if the target is null (no player with the "Player" tag found)
        if (target == null)
        {
            // Continue with the boss's movement or provide alternative behavior
            Vector2 newPos1 = new Vector2(animator.transform.position.x + speed * Time.deltaTime, animator.transform.position.y);
            animator.transform.position = newPos1;

            // You may want to handle other actions or conditions here
            return;
        }

        Vector2 newPos = new Vector2(target.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, newPos, speed * Time.deltaTime);

        if (Physics2D.Raycast(borderCheck.position, Vector2.down, 2) == false)
            animator.SetBool("IsWalk", false);

        float distance = Vector2.Distance(target.position, animator.transform.position);
        if (distance < 1.5)
            animator.SetBool("IsAttack", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Additional cleanup or actions when exiting the state
    }
}
