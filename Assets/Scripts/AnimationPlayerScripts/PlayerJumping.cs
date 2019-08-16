using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping: StateMachineBehaviour
{
    // Reference
    MovementController _movementController;
    Rigidbody2D _rigidbody;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _movementController = animator.GetComponent<MovementController>();
    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_movementController.movementState.Equals(MovementState.Ground) || 
            _movementController.movementState.Equals(MovementState.Running)) animator.SetBool("isJumping", false);
        bool isJumpDown = animator.GetFloat("JumpVelocity") > 0 && _rigidbody.velocity.y < 0;
        bool isJumpUp = animator.GetFloat("JumpVelocity") < 0 && _rigidbody.velocity.y > 0;
        if(isJumpDown || isJumpUp) animator.SetFloat("JumpVelocity", _rigidbody.velocity.y);
        Debug.Log(_rigidbody.velocity.y);

        //if (_playerMovement)
        //animator.SetFloat("JumpingVelocity",)
        //if (animator.GetComponent<Rigidbody2D>().velocity.y < 0 || 
        //    animator.GetComponent<PlayerMovement>().isGrounded) animator.SetBool("isJumping_Down", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.SetBool("isJumping_Up", false);
    }
}
