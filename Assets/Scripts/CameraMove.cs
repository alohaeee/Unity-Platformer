using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour
{
    [SerializeField] GameStatuses _gameStatuses;
    [SerializeField] Transform _target;
    Transform _cameraTransform;
    Camera _cameraComponent;

    [Range(0f, 0.3f)] [SerializeField] float _movementSmoothing = 0.05f;
    Vector3 _curVelocity = Vector3.zero;

    [Space]
    [Header("Camera's Edges")]
 
    [SerializeField] bool _yMaxEnabled = false;
    [SerializeField] float _yMax = 0f;

    [SerializeField] bool _yMinEnabled = false;
    [SerializeField] float _yMin = 0f;

    [SerializeField] bool _xMaxEnabled = false;
    [SerializeField] float _xMax = 0f;

    [SerializeField] bool _xMinEnabled = false;
    [SerializeField] float _xMin = 0f;



    private void Start()
    {
        _cameraTransform = GetComponent<Transform>();
        _cameraComponent = GetComponent<Camera>();
    }
    private void FixedUpdate()
    {
        if (_gameStatuses.Status() == GameStatus.Playing)
        {
            Vector3 targetPos = _target.position;

            //Keep camera position in granted values
            if (_yMaxEnabled && _yMinEnabled)
                targetPos.y = Mathf.Clamp(_target.position.y, _yMin, _yMax);
            else if (_yMinEnabled) targetPos.y = Mathf.Clamp(_target.position.y, _yMin, _target.position.y);
            else if (_yMaxEnabled) targetPos.y = Mathf.Clamp(_target.position.y, _target.position.y, _yMax);

            if (_xMaxEnabled && _xMinEnabled)
                targetPos.x = Mathf.Clamp(_target.position.x, _xMin, _xMax);
            else if (_xMinEnabled) targetPos.x = Mathf.Clamp(_target.position.x, _xMin, targetPos.x);
            else if (_xMaxEnabled) targetPos.x = Mathf.Clamp(_target.position.x, targetPos.x, _xMax);
 
            targetPos.z = _cameraTransform.position.z;

            _cameraTransform.position = Vector3.SmoothDamp(_cameraTransform.position, targetPos, ref _curVelocity, _movementSmoothing);
        }
    }
  
}
