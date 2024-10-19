using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        UpdateScore();
    }

    public void IncreaseScore(int amount = 1)
    {
        score += amount; 
        UpdateScore(); 
    }

    public void ResetScore()
    {
        score = 0;  
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
