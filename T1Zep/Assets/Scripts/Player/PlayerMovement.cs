using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🏃 PlayerMovement.cs
/// 플레이어의 이동 입력을 받아 Rigidbody2D의 속도로 반영하는 클래스
/// - 중력이 꺼져 있을 때는 y축 이동도 가능
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // 💨 이동 속도

    private Rigidbody2D rb;

    /// <summary>
    /// ⚙️ Rigidbody2D 참조 초기화
    /// </summary>
    public void Initialize(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
    }

    /// <summary>
    /// 🎮 입력값에 따라 Rigidbody 이동 처리
    /// </summary>
    /// <param name="input">이동 입력 (좌우 / 상하)</param>
    public void Move(Vector2 input)
    {
        Vector2 velocity = rb.velocity;

        // ↔️ 좌우 이동은 항상 가능
        velocity.x = input.x * moveSpeed;

        // ⬆⬇ 중력이 꺼져 있을 경우에만 상하 이동 허용 (예: 점프 전 대기 상태)
        if (rb.gravityScale == 0f)
        {
            velocity.y = input.y * moveSpeed;
        }

        // 🚀 속도 적용
        rb.velocity = velocity;
    }
}
