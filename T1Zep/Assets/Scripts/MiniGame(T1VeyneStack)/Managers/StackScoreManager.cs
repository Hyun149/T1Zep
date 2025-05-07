using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 📊 StackScoreManager.cs
/// 스택 미니게임에서 점수를 관리하는 싱글턴 매니저
/// - 점수 추가, 조회, 초기화 기능 제공
/// </summary>
public class StackScoreManager : MonoBehaviour
{
    public static StackScoreManager Instance { get; private set; } // 🌐 전역 접근 가능한 싱글턴 인스턴스

    private int currentScore = 0; // 📈 현재 점수

    private void Awake()
    {
        // ✅ 싱글턴 패턴 구현: 중복 인스턴스 방지
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 이미 존재할 경우 파괴
        }
    }

    /// <summary>
    /// ➕ 점수 추가
    /// </summary>
    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    /// <summary>
    /// 📤 현재 점수 조회
    /// </summary>
    public int GetScore()
    {
        return currentScore;
    }

    /// <summary>
    /// 🔄 점수 초기화
    /// </summary>
    public void ResetScore()
    {
        currentScore = 0;
    }
}
