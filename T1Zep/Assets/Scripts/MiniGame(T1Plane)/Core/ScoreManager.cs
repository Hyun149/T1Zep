using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager
{
    private int currentScore;
    private Text scoreText;

    public ScoreManager(Text scoreText)
    {
        this.scoreText = scoreText;
        ResetScore();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Á¡¼ö: {currentScore}";
        }
    }

    public int GetScore()
    {
        return currentScore;
    }
}
