using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ⚙️ PlanePhysics.cs
/// 비행기의 중력, 점프, 넉백, 좌우 이동 등 물리 기반 이동 처리 담당
/// Rigidbody2D를 직접 조작하여 실시간 반응 구현
/// </summary>
public class PlanePhysics : MonoBehaviour
{
    [SerializeField] private float Gravity = 1f;              // ⬇️ 중력 가속도
    [SerializeField] private float MaxY = 4.5f;               // ⬆️ 최대 상승 높이 제한
    [SerializeField] private float baseJumpForce = 5f;        // 🛫 기본 점프 힘
    [SerializeField] private float jumpDecay = 0.5f;          // 🔻 점프 감소량
    [SerializeField] private float minJumpForce = 2f;         // ⬇️ 최소 점프력
    [SerializeField] private float horizontalSpeed = 3f;      // ➡️ 좌우 이동 속도

    private Rigidbody2D rb;               // 🎯 물리 제어용 컴포넌트
    private float verticalVelocity = 0f;  // ⬆️⬇️ 수직 속도 저장용
    private JumpHandler jumpHandler;      // 🧠 점프력 감쇠 관리 유틸 클래스

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody 연결
    }

    private void Start()
    {
        // 🔧 점프 힘 초기화 핸들러 생성
        jumpHandler = new JumpHandler(baseJumpForce, jumpDecay, minJumpForce);
    }

    /// <summary>
    /// ⬆️ 점프 입력 발생 시 현재 점프력으로 수직 속도 적용
    /// </summary>
    public void ApplyJump()
    {
        verticalVelocity = jumpHandler.GetForce();
    }

    /// <summary>
    /// ⬇️ 중력을 수직 속도에 반영하고 Rigidbody에 적용
    /// Y 위치가 MaxY를 초과하면 위치 및 속도 제한
    /// </summary>
    public void ApplyGravity()
    {
        verticalVelocity -= Gravity * Time.fixedDeltaTime;

        Vector2 velocity = rb.velocity;
        velocity.y = verticalVelocity;
        rb.velocity = velocity;

        float clampedY = Mathf.Min(transform.position.y, MaxY);
        transform.position = new Vector2(transform.position.x, clampedY);

        if (transform.position.y >= MaxY)
        {
            verticalVelocity = 0f; // 상승 제한 시 정지
        }
    }

    /// <summary>
    /// 💥 충돌한 지점에서 멀어지는 방향으로 넉백 적용
    /// </summary>
    /// <param name="from">충돌 지점</param>
    /// <param name="force">넉백 힘</param>
    public void ApplyKnockback(Vector2 from, float force)
    {
        Vector2 dir = ((Vector2)transform.position - from).normalized;
        rb.velocity = Vector2.zero;
        rb.velocity = dir * force;
    }

    /// <summary>
    /// ➡️ 좌우 입력에 따라 수평 속도 적용
    /// </summary>
    public void ApplyHorizontalMovement(float input)
    {
        Vector2 velocity = rb.velocity;
        velocity.x = input * horizontalSpeed;
        rb.velocity = velocity;
    }

    /// <summary>
    /// 🔻 점프력을 감쇠시켜 점점 약한 점프 구현
    /// </summary>
    public void ReduceJumpForce()
    {
        jumpHandler.Reduce();
    }
}
