using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 💀 GameOverChecker.cs
/// 오브젝트가 화면 경계를 벗어났는지(Game Over 조건)를 판별하는 유틸리티
/// - X축: 우측 제한 (xLimit 이상이면 벗어남)
/// - Y축: 아래 제한 (yLimit 이하이면 낙사)
/// </summary>
public class GameOverChecker : MonoBehaviour
{
    [SerializeField] private float xLimit = 10f;     // ➡️ 우측 경계 한계값 (넘으면 게임오버)
    [SerializeField] private float yLimit = -5.7f;    // ⬇️ 아래쪽 경계 한계값 (낙사 기준)

    /// <summary>
    /// 🎯 전달된 위치가 경계를 벗어났는지 여부를 반환
    /// </summary>
    /// <param name="position">판별할 위치 (예: 플레이어 위치)</param>
    /// <returns>true: 경계 벗어남 / false: 정상 범위</returns>
    public bool IsOutOfBounds(Vector2 position)
    {
        // ✅ 조건 1: X축이 오른쪽 한계 초과
        // ✅ 조건 2: Y축이 바닥 아래로 낙하
        return position.x > xLimit || position.y <= yLimit;
    }
}
