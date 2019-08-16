using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : AI
{
    // Reference to enemy's components
    Transform enemyTransform;
    DataEnemy dataEnemy;
    [SerializeField] ParticleSystem dieParticle;

    // Time out to Destroy particle system after destroy object 
    [SerializeField] float timeOut = 1f;

    // Current target to move
    int curTarget = 0;

    bool isPlus;


    private void Start() 
    {
        enemyTransform = GetComponent<Transform>();
        dataEnemy = GetComponent<DataEnemy>();
        SetCurTarget(curTarget);
    }

    private void Update()
    {
        
        Move();
        if (isReached())
        {
            if (curTarget <= 0) isPlus = true;
            else if (curTarget >= targets.Length - 1) isPlus = false;
            if (isPlus) curTarget++;
            else curTarget--;
            SetCurTarget(curTarget);

        } 
    }

    public void Die()
    {
        ParticleSystem dieParticleCopy = Instantiate(dieParticle, enemyTransform.position, enemyTransform.rotation) as ParticleSystem;
        dieParticleCopy.Play();
        Destroy(dieParticleCopy.gameObject, timeOut);
        Destroy(gameObject);
    }
}
