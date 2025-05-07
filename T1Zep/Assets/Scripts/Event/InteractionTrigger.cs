using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🧩 InteractionTrigger.cs
/// 플레이어가 특정 오브젝트에 접근 시 UI 활성화 트리거
/// - OnTriggerEnter2D: UI 활성화
/// - OnTriggerExit2D: UI 비활성화
/// </summary>
public class InteractionTrigger : MonoBehaviour
{
    [SerializeField] private UIActivator UIActivator;  // 📺 UI 활성화/비활성화 담당 스크립트 참조

    /// <summary>
    /// ✅ 플레이어가 트리거 범위에 들어오면 UI를 활성화합니다.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ✅ null 체크 포함 → UIActivator가 존재할 경우만 Activate() 실행
            UIActivator?.Activate();
        }
    }

    /// <summary>
    /// ✅ 플레이어가 트리거 범위를 벗어나면 UI를 비활성화합니다.
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // ✅ null 체크 포함 → UIActivator가 존재할 경우만 Deactivate() 실행
            UIActivator?.Deactivate();
        }
    }
}
