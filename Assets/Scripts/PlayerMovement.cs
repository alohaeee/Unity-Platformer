using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    MovementController _movementController;
    [SerializeField] GameStatuses _gameStatuses;
    [SerializeField] float _speed = 5f;
    // Fields for Move function
    bool _jump = false;
    float _horizontalMove = 0f;
 

    //
    Animator _animator;
    Rigidbody2D _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movementController = GetComponent<MovementController>();
    }
    private void FixedUpdate()
    {
        if(_gameStatuses.Status().Equals(GameStatus.Playing))
        {
            _movementController.Move(_horizontalMove * Time.fixedDeltaTime, _jump);
            _jump = false;
        }
        
    }
    private void Update()
    {
        if (_gameStatuses.Status() == GameStatus.Playing)
        {
            _horizontalMove = Input.GetAxis("Horizontal") * _speed;
            if (Input.GetButtonDown("Jump"))
            {
                _jump = true;
            }
            
        }
        

    }


}

