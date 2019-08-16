using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraZoom : MonoBehaviour
{
    [SerializeField] GameStatuses _gameStatuses;
    [SerializeField] Transform _target;

    Camera _camera;

    [SerializeField] float _smooth = 5f;
    [SerializeField] float _zoom = 4f;


    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if(_gameStatuses.Status() == GameStatus.LevelEnd)
        {
            _camera.fieldOfView = Mathf.Lerp(_camera.fieldOfView, _zoom, _smooth * Time.deltaTime);
        }
        
    }
}
