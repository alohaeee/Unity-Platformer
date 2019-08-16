using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    Animator _animator;
    ParticleSystem _particleSystem;
    [SerializeField] GameStatuses _gameStatuses;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _particleSystem = GetComponentInChildren<ParticleSystem>();
        
    }
    public void Touch()
    {
        _particleSystem.Play();
        _animator.SetTrigger("isTouched");
        _gameStatuses.FinishLevel();
    }
}
