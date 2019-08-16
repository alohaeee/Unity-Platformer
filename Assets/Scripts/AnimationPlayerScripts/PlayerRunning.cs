using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : StateMachineBehaviour
{
    MovementController _movementController;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _movementController = animator.GetComponent<MovementController>();
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_movementController.movementState.Equals(MovementState.Ground)) animator.SetBool("isRunning", false);
        else if (_movementController.movementState.Equals(MovementState.Jumping))
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", true);
            animator.SetFloat("JumpVelocity", 1f);
        }
                
    }
}
