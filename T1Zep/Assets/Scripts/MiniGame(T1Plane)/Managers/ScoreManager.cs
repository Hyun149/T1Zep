using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 📊 ScoreManager.cs
/// 게임 점수 로직을 관리하는 클래스 (비 MonoBehaviour)
/// - 점수 초기화, 증가, 저장 및 UI 반영 담당
/// </summary>
public class ScoreManager
{
    private int currentScore;              // 🟡 현재 점수
    private Text scoreText;                // 🖥 현재 점수 표시용 텍스트
    private Text bestScoreText;            // 🏆 최고 점수 표시용 텍스트

    /// <summary>
    /// 🛠 생성자: 점수 텍스트를 받아 초기화 수행
    /// </summary>
    public ScoreManager(Text scoreText, Text bestScoreText)
    {
        this.scoreText = scoreText;
        this.bestScoreText = bestScoreText;
        ResetScore(); // 점수 초기화
    }

    /// <summary>
    /// ➕ 점수를 증가시키고 UI에 반영
    /// </summary>
    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateUI();
    }

    /// <summary>
    /// 🔄 점수를 0으로 초기화하고 UI 갱신
    /// </summary>
    public void ResetScore()
    {
        currentScore = 0;
        UpdateUI();
    }

    /// <summary>
    /// 🖥 현재 점수를 UI에 반영
    /// </summary>
    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"점수: {currentScore}";
        }
    }

    /// <summary>
    /// 📤 현재 점수를 반환
    /// </summary>
    public int GetScore()
    {
        return currentScore;
    }

    /// <summary>
    /// 🏁 게임 종료 시 점수를 저장하고 최고 점수 UI 업데이트
    /// </summary>
    public void FinalizeScore()
    {
        ScoreSaveSystem.SaveScore(currentScore);
        UpdateBestScoreUI();
    }

    /// <summary>
    /// 🏆 최고 점수를 불러와 UI에 표시
    /// </summary>
    private void UpdateBestScoreUI()
    {
        if (bestScoreText != null)
        {
            int bestScore = ScoreSaveSystem.GetBestScore();
            bestScoreText.text = $"최고점수: {bestScore}";
        }
    }
}
