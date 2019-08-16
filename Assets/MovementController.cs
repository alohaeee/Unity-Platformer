using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState
{
    Ground,
    Running,
    Jumping
}
public class MovementController : MonoBehaviour
{
    // Inspector values
    [SerializeField] private float _jumpForce = 3f;
    [Range(0f, 0.3f)]
    [SerializeField] private float _movementSmoothing = 0.05f;
    [SerializeField] private bool _airControll = true;

    // Reference
    Transform _selfTransform;
    Rigidbody2D _rigidbody;
    [SerializeField] LayerMask _whatIsGround;
    [SerializeField] Transform _groundCheck;


    // Logical values
    [HideInInspector] public bool isGrounded = false;
    bool _rightFacing = true;
    //Vector2 _targetVelocity;
    Vector2 _curVelocity = Vector2.zero;
    const float _groundedRadius = .25f;


    [HideInInspector] public MovementState movementState;

    



    private void Start()
    {
        _selfTransform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        movementState = MovementState.Ground;
    }
    private void FixedUpdate()
    {
        GroundCheck();
    }
    // Moving implementation 
    public void Move(float move, bool jump)
    {
        if (movementState.Equals(MovementState.Ground) || _airControll)
        {
            Vector2 targetVelocity = new Vector2(move * 10f, _rigidbody.velocity.y);
            _rigidbody.velocity = Vector2.SmoothDamp(_rigidbody.velocity, targetVelocity, ref _curVelocity, _movementSmoothing);
            if (movementState.Equals(MovementState.Ground) && move != 0) movementState = MovementState.Running;
            else if(movementState.Equals(MovementState.Running) && move == 0) movementState = MovementState.Ground;
        }

        if (move > 0 && !_rightFacing) Flip();
        else if (move < 0 && _rightFacing) Flip();

        if (!movementState.Equals(MovementState.Jumping) && jump)
        {
            movementState = MovementState.Jumping;
            isGrounded = false;
            _rigidbody.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
        }
    }

    // Flip local scale
    private void Flip()
    {
        _rightFacing = !_rightFacing;
        Vector2 characterScale = _selfTransform.localScale;
        characterScale.x *= -1;
        _selfTransform.localScale = characterScale;
    }

    // Check with overlap circle on ground check position if player stay on whatIsGround
    private void GroundCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_groundCheck.position, _groundedRadius, _whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                movementState = MovementState.Ground;
            }
        }
    }
    private void OnDisable()
    {
        Move(0f, false);
    }
}
