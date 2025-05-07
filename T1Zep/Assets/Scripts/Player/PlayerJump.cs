using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

/// <summary>
/// ⬆️ PlayerJump.cs
/// 2D 캐릭터의 점프 로직을 처리하는 클래스
/// - 중력 설정, 점프 요청, 착지 체크, y 위치 고정 포함
/// </summary>
public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float flapForce = 15.0f; // ⬆️ 점프 힘 (위로 튀어오르는 속도)

    private Rigidbody2D rb;
    private float jumpStartY;     // ⬆️ 점프 시작 y 위치 (착지 계산에 사용)
    private bool isJumping;       // ▶️ 현재 점프 중인지 여부
    private bool canJump;         // ✅ 점프 가능 여부 (초기 지연용)

    /// <summary>
    /// 🔧 Rigidbody2D 연결 및 초기 중력/속도 설정
    /// </summary>
    public void Initialize(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
        rb.gravityScale = 0f;               // 중력 비활성화로 초기 위치 고정
        rb.velocity = Vector2.zero;         // 속도 초기화
        StartCoroutine(EnableJump());       // 짧은 대기 후 점프 가능
    }

    /// <summary>
    /// 🕒 점프 활성화까지 0.1초 대기 (초기 씬 로딩 시 안정성 확보용)
    /// </summary>
    private IEnumerator EnableJump()
    {
        yield return new WaitForSeconds(0.1f);
        canJump = true;
    }

    public bool IsJumping => isJumping; // 외부에서 점프 상태 확인 가능

    /// <summary>
    /// ⬆️ 점프 요청 (중복 방지 및 중력 활성화 포함)
    /// </summary>
    public void RequestJump()
    {
        if (!canJump || isJumping) return;

        rb.gravityScale = 1f;                             // 중력 활성화
        jumpStartY = transform.position.y;                // 점프 시작 위치 저장
        rb.velocity = new Vector2(rb.velocity.x, flapForce); // 수직 속도 부여
        isJumping = true;
    }

    /// <summary>
    /// ⬇️ 점프 후 착지 감지 및 위치 보정
    /// </summary>
    public void CheckLanding()
    {
        if (isJumping && rb.velocity.y <= 0f && transform.position.y <= jumpStartY)
        {
            rb.gravityScale = 0f;                         // 중력 제거
            rb.velocity = Vector2.zero;                   // 속도 정지
            transform.position = new Vector3(transform.position.x, jumpStartY, transform.position.z); // y 위치 정렬
            isJumping = false;                            // 점프 종료
        }
    }
}
