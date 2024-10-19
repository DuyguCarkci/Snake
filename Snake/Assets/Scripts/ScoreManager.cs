using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;  // UI'deki Score Text'i
    private int score = 0;  // Baþlangýç skoru

    void Start()
    {
        UpdateScore();  // Oyun baþladýðýnda skoru güncelle
    }

    // Skoru artýr ve ekranda göster
    public void IncreaseScore(int amount = 1)
    {
        score += amount;  // Skoru belirtilen miktarda artýr
        UpdateScore();  // Skoru ekranda güncelle
    }

    // Skoru sýfýrla ve güncelle
    public void ResetScore()
    {
        score = 0;  // Skoru sýfýrla
        UpdateScore();  // Güncellenmiþ skoru ekranda göster
    }

    // UI'deki skoru güncelle
    private void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();  // UI Text'ini güncelle
    }
}
