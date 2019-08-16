using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : StateMachineBehaviour
{
    // Reference 
    MovementController _movementController;
    Rigidbody2D _rigidbody;
    // Fields to set blink animation
    float _blinkTime = 3f;
    float _blinkDelta;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _movementController = animator.GetComponent<MovementController>();
        _rigidbody = animator.GetComponent<Rigidbody2D>();
        _blinkDelta = 0f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if (Input.GetAxis("Horizontal") != 0 && pm.isGrounded) animator.SetBool("isRunning", true);
        //if (!pm.isGrounded)
        //{
        //    if(rb.velocity.y>0)
        //        animator.SetBool("isJumping_Up", true);
        //    if (rb.velocity.y < 0)
        //        animator.SetBool("isJumping_Down", true);
        //}
        //if (_playerMovement.isMoving() && _playerMovement.isGrounded) animator.SetBool("isRunning", true);
        //if (_playerMovement.isJumping())
        //{
        //    animator.SetBool("isJump", _playerMovement.isJump());
        //}
        _blinkDelta += Time.deltaTime;
        if (_movementController.movementState.Equals(MovementState.Running)) animator.SetBool("isRunning", true);
        else if (_movementController.movementState.Equals(MovementState.Jumping))
        {
            animator.SetBool("isJumping", true);
            animator.SetFloat("JumpingVelocity", 1f);
        }
        else if(_rigidbody.velocity.y !=0)
        {
            animator.SetBool("isJumping", true);
            animator.SetFloat("JumpingVelocity", _rigidbody.velocity.y);
        }
        else if (_movementController.movementState.Equals(MovementState.Ground))
        {
            if (_blinkDelta > _blinkTime)
            {
                _blinkDelta = 0;
                animator.SetTrigger("isBlink");
            }
        }
    }
}
