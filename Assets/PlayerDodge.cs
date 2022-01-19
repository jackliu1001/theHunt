using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : StateMachineBehaviour
{
    public BoxCollider2D playerCollider;
    private Vector2 defaultSize, defaultOffset;
    public Vector2 dodgeSize, dodgeOffset;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCollider = animator.transform.parent.GetComponent<BoxCollider2D>();
        defaultSize = playerCollider.size;
        defaultOffset = playerCollider.offset;

        playerCollider.offset = dodgeOffset;
        playerCollider.size = dodgeSize;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerCollider.offset = defaultOffset;
        playerCollider.size = defaultSize;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
