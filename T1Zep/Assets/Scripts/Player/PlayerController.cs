using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🕹 PlayerController.cs
/// 플레이어의 이동, 점프, 입력 처리, 방향 반전을 통합 제어하는 2D 플레이어 컨트롤러
/// - PlayerMovement, PlayerJump, PlayerInputHandler 의존
/// - Sprite 방향(flipX) 전환 포함
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;      // 👤 방향 반전을 위한 스프라이트 렌더러
    [SerializeField] private PlayerMovement movement;            // 🏃 이동 로직 처리 클래스
    [SerializeField] private PlayerInputHandler inputHandler;    // ⌨️ 입력 처리 클래스

    private PlayerJump jumper;                                   // ⬆️ 점프 처리 클래스
    private Rigidbody2D rb;                                      // ⚙️ 물리 엔진 처리용 Rigidbody2D

    private void Awake()
    {
        // 🔁 컴포넌트 초기화 및 참조 연결
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
        movement = GetComponent<PlayerMovement>();
        jumper = GetComponent<PlayerJump>();

        // ⚙️ 물리 컴포넌트 초기화 전달
        movement.Initialize(rb);
        jumper.Initialize(rb);
    }

    private void Update()
    {
        inputHandler.ProcessInput(); // ⌨️ 입력 감지

        if (inputHandler.JumpPressed)
        {
            jumper.RequestJump();    // ⬆️ 점프 요청
        }

        movement.Move(inputHandler.MoveInput); // 🏃 이동 처리

        HandleFlip(inputHandler.MoveInput.x);  // ↔️ 방향 반전 처리
    }

    private void FixedUpdate()
    {
        jumper.CheckLanding(); // 🛬 착지 여부 판정
    }

    /// <summary>
    /// ↔️ 좌우 입력에 따라 스프라이트 좌우 반전 처리
    /// </summary>
    private void HandleFlip(float horizontal)
    {
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
