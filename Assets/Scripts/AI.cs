using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Reference to this object Transform
    Transform transformAI;

    // Simple AI movement options
    [Header("AI moving options")]
    [SerializeField] protected float Speed = 0f;
    [SerializeField] protected float stopDistance = 0f;

    // Current flag to our path
    int curDestination;

    // Array of transform components of targets
    [SerializeField] protected Transform[] targets;
    
    
    private void Awake()
    {
        transformAI = GetComponent<Transform>();
    }
    
    //  Set cur destination from already existed pathes
    public void SetCurTarget(int number)
    {
        curDestination = number;
        
    }

    // Change object's position with MoveTowards method
    public void Move()
    {
        transformAI.position = Vector2.MoveTowards(transformAI.position, targets[curDestination].position, Speed * Time.deltaTime);
    }

    // Return true if distance between Object and current Destination is less then stopDistance.
    // Otherwise return false.
    public bool isReached()
    {
        
        if (Vector2.Distance(transformAI.position, targets[curDestination].position) > stopDistance) return false;
        else return true;
    }

}
