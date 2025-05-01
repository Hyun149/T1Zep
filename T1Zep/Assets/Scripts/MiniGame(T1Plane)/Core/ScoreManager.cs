using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager
{
    private int currentScore;
    private Text scoreText;
    private Text bestScoreText;

    public ScoreManager(Text scoreText, Text bestScoreText)
    {
        this.scoreText = scoreText;
        this.bestScoreText = bestScoreText;
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
            scoreText.text = $"점수: {currentScore}";
        }
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void FinalizeScore()
    {
        ScoreSaveSystem.SaveScore(currentScore);
        UpdateBestScoreUI();
    }

    private void UpdateBestScoreUI()
    {
        if (bestScoreText != null)
        {
            int bestScore = ScoreSaveSystem.GetBestScore();
            bestScoreText.text = $"최고점수: {bestScore}";
        }
    }
}
