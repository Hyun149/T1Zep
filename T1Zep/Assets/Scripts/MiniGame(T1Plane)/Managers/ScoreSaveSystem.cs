using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 💾 ScoreSaveSystem.cs
/// PlayerPrefs를 사용하여 최고 점수를 저장하고 불러오는 정적 저장 시스템
/// - 기존 최고 점수보다 높은 경우에만 저장
/// - 기본값은 0점
/// </summary>
public class ScoreSaveSystem : MonoBehaviour
{
    private const string BestScoreKey = "BestScore"; // 🏷 저장에 사용되는 키 값 (PlayerPrefs 키)

    /// <summary>
    /// 📥 최고 점수를 저장 (현재 점수가 더 높을 경우만 저장)
    /// </summary>
    /// <param name="score">현재 게임에서 획득한 점수</param>
    public static void SaveScore(int score)
    {
        int bestScore = GetBestScore();

        // ✅ 예외 처리: 기존 최고 점수보다 높을 경우에만 저장
        if (score > bestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey, score);
            PlayerPrefs.Save(); // ⚠️ 실제 디스크에 저장
        }
    }

    /// <summary>
    /// 📤 저장된 최고 점수를 반환 (없을 경우 기본값 0)
    /// </summary>
    public static int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0); // ✅ 예외 처리: 값이 없으면 0 반환
    }
}
