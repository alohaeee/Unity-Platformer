using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer : MonoBehaviour
{
    // Player Name
    [HideInInspector] public string playerName = null;
    // Player current Score
    [HideInInspector] public int score = 0;
    // Player live status
    [HideInInspector] public bool isAlive = true;
    // 
    [HideInInspector] public int beginLevelScore = 0;
}
