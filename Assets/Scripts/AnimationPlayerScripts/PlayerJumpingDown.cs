using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingDown : StateMachineBehaviour
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
        Debug.Log(_rigidbody.velocity.y);
        if (_movementController.movementState.Equals(MovementState.Ground) ||
            _movementController.movementState.Equals(MovementState.Running)) animator.SetBool("isJumping", false);
        else if (_rigidbody.velocity.y > 0) animator.SetFloat("JumpVelocity", _rigidbody.velocity.y);
    }

}
