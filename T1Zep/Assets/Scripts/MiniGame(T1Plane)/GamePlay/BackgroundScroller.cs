using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🌄 BackgroundScroller.cs
/// 배경 오브젝트를 일정 속도로 오른쪽 방향으로 이동시켜 스크롤 효과를 주는 스크립트
/// - 게임 시작 상태일 때만 이동
/// </summary>
public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 2f; // 🌀 배경 스크롤 속도

    private void Update()
    {
        // ✅ 예외 처리: 게임이 시작되지 않았을 경우 이동 중단
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        // ➡️ 오른쪽(X+) 방향으로 스크롤 이동
        transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
    }
}
