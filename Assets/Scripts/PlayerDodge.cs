using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDodge : StateMachineBehaviour
{
    public BoxCollider2D player;
    private Vector2 originalCollider;
    public Vector2 dodgeCollider;
    private Vector2 originalOffset;
    public Vector2 dodgeOffset;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.transform.parent.GetComponent<BoxCollider2D>();
        originalCollider = player.size;
        originalOffset = player.offset;

        player.offset = dodgeOffset;
        player.size = dodgeCollider;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.offset = originalOffset;
        player.size = originalCollider;
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
