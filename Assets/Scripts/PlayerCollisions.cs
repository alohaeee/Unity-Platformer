using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerCollisions : MonoBehaviour
{
    // Reference of player's components
    MovementController _movementController;
    PlayerScore _playerScore;
    PlayerSimulator _playerSimulator;  

    // Reference to Game Status Controller
    [SerializeField] GameStatuses _gameStatuses;

    private void Start()
    {
        _movementController = GetComponent<MovementController>();
        _playerScore = GetComponent<PlayerScore>();
        _playerSimulator = GetComponent<PlayerSimulator>();
       
    }
    private void FixedUpdate()
    {
        /*strange behaviour
         playerController.GroundCheck()*/

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            foreach(ContactPoint2D hitPos in collision.contacts)
            {
                // If we hit enemy on bottom add to score destroy score and destroy Enemy
                if (hitPos.normal.y > 0)
                {
                    _movementController.movementState = MovementState.Ground;
                    _playerScore.AddToScore(collision.gameObject.GetComponent<DataEnemy>().destroyScore);
                    collision.gameObject.GetComponent<EnemyMovement>().Die();
                    break;
                }
                // Else simulate player's death and calls end game;
                else
                {
                    _gameStatuses.EndGame();
                    _playerSimulator.SimulateDeath();
                    break;
                }
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // End game if player hit water
        if (collision.gameObject.CompareTag("Water"))
        {
            _gameStatuses.EndGame();
            _playerSimulator.SimulateDeath();
        }
        // 
        else if (collision.gameObject.CompareTag("Coin"))
        {
            _playerScore.AddToScore(collision.gameObject.GetComponent<DataCoin>().destroyScore);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Chest"))
        {
            collision.GetComponent<Chest>().Touch();
            _playerSimulator.OffRigidbody();
        }
    }

}
