using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🦘 JumpHandler.cs
/// 점프 힘(force)을 관리하는 유틸리티 클래스
/// - 충돌할수록 힘이 감소 (감쇠)
/// - 최소값 이하로는 내려가지 않도록 제한
/// - 점프 초기화 기능 포함
/// </summary>
public class JumpHandler
{
    private float current;             // 💥 현재 점프 힘
    private readonly float min;       // ⬇️ 점프 힘의 최소값
    private readonly float decay;     // 🔻 점프 시 감소할 감쇠값

    /// <summary>
    /// 🛠 생성자: 초기 점프력, 감쇠 속도, 최소 점프력 설정
    /// </summary>
    /// <param name="baseForce">초기 점프력</param>
    /// <param name="decay">점프 시마다 감소할 양</param>
    /// <param name="min">점프력 최소 제한</param>
    public JumpHandler(float baseForce, float decay, float min)
    {
        current = baseForce;
        this.decay = decay;
        this.min = min;
    }

    /// <summary>
    /// 📤 현재 점프 힘을 반환
    /// </summary>
    public float GetForce() => current;

    /// <summary>
    /// 🔻 점프 힘을 감소시키되, 0보다 작아지지 않도록 제한
    /// </summary>
    public void Reduce() => current = Mathf.Max(0f, current - decay);

    /// <summary>
    /// 🔄 점프 힘을 외부 값으로 초기화
    /// </summary>
    public void ResetJumpForce(float value) => current = value;
}
