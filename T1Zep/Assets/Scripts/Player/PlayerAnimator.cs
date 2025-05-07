using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🎞 PlayerAnimator.cs
/// 플레이어의 애니메이터 상태를 제어하는 전용 클래스
/// - 'isRunning' 파라미터를 통해 이동 애니메이션 상태 관리
/// </summary>
public class PlayerAnimator : MonoBehaviour
{
    private Animator animator; // 🎬 Unity Animator 컴포넌트

    private void Awake()
    {
        // 🎥 Animator 컴포넌트 참조 캐싱
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// 🏃 이동 여부에 따라 'isRunning' 애니메이션 상태 설정
    /// </summary>
    /// <param name="isRunning">이동 중인지 여부</param>
    public void UpdateRunning(bool isRunning)
    {
        animator.SetBool("isRunning", isRunning);
    }
}
