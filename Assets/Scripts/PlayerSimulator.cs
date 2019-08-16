using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSimulator : MonoBehaviour
{
    // Reference to player's components
    DataPlayer playerData;
    PlayerScore playerScore;
    ParticleSystem _dieParticle;
    SpriteRenderer _spriteRenderer;
    Transform _transform;
    Rigidbody2D _rigidbody;
    MovementController _movementController;
    PlayerMovement _playerMovement;
    // UnityEvent for SimulateDeath method.
    [SerializeField] UnityEvent OnDeath;
    [SerializeField] GameObject _playerLevelEndPrefab;
    [SerializeField] float timeOut = 1f;


    private void Start()
    {
        playerData = GetComponent<DataPlayer>();
        playerScore = GetComponent<PlayerScore>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _dieParticle = GetComponentInChildren<ParticleSystem>();
        _transform = GetComponent<Transform>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _movementController = GetComponent<MovementController>();
    }

    private void Update()
    {
        
    }

    // Change player's isAlive field to false and Invoke OnDeath Event.
    public void SimulateDeath()
    {
        OnDeath.Invoke();
    }

    public void OffRigidbody()
    {
        _movementController.enabled = false;
        
    }
    public void SetLevelEndPrefab()
    {
        var s = Instantiate(_playerLevelEndPrefab) as GameObject;
        _playerLevelEndPrefab.GetComponent<Rigidbody2D>().velocity = _rigidbody.velocity;
    }
}
