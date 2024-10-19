using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // UI'deki Score Text'i
    private int score = 0;  // Ba�lang�� skoru

    void Start()
    {
        UpdateScore();  // Oyun ba�lad���nda skoru g�ncelle
    }

    // Skoru art�r ve ekranda g�ster
    public void IncreaseScore(int amount = 1)
    {
        score += amount;  // Skoru belirtilen miktarda art�r
        UpdateScore();  // Skoru ekranda g�ncelle
    }

    // Skoru s�f�rla ve g�ncelle
    public void ResetScore()
    {
        score = 0;  // Skoru s�f�rla
        UpdateScore();  // G�ncellenmi� skoru ekranda g�ster
    }

    // UI'deki skoru g�ncelle
    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();  // UI Text'ini g�ncelle
    }
}
