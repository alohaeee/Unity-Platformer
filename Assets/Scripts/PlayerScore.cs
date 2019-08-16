using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    // Reference to Player's Data 
    DataPlayer dataPlayer;
    // Reference to text that represent score on the screen
    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        dataPlayer = GetComponent<DataPlayer>();
        AddToScore(dataPlayer.beginLevelScore);
    }
    
    public void SetBeginScore()
    {
        dataPlayer.score = dataPlayer.beginLevelScore;
    }

    // Change Player's score and change UI score text;
    public void AddToScore(int x)
    {
        dataPlayer.score += x;
        scoreText.SetText(dataPlayer.score.ToString());
    }
}
