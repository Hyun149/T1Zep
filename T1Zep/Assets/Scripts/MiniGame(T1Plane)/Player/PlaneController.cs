using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ✈️ PlaneController.cs
/// 플레이어 비행기의 입력 처리, 충돌 판정, 중력 적용 등을 담당하는 핵심 제어 스크립트
/// </summary>
public class PlaneController : MonoBehaviour
{
    [SerializeField] private float knockbackTime = 0.3f; // 💥 넉백 지속 시간

    private bool isKnockback = false; // ⛔ 넉백 상태 중에는 조작 제한

    private MiniGameManager miniGameManager;
    private PlanePhysics planePhysics;
    private HitEffectSpawner effectSpawner;
    private GameOverChecker gameOverChecker;

    private void Awake()
    {
        // 🔧 주요 컴포넌트 및 매니저 참조 획득
        miniGameManager = FindObjectOfType<MiniGameManager>();
        planePhysics = GetComponent<PlanePhysics>();
        effectSpawner = GetComponent<HitEffectSpawner>();
        gameOverChecker = GetComponent<GameOverChecker>();
    }

    private void Update()
    {
        // ✅ 예외 처리: 게임이 시작되지 않았으면 조작 불가
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        // 🆙 Space 키 입력 시 점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            planePhysics.ApplyJump();
        }

        // ☠️ 화면 밖으로 벗어나면 게임 종료
        if (gameOverChecker.IsOutOfBounds(transform.position))
        {
            MiniGameManager.Instance.EndGame();
        }
    }

    private void FixedUpdate()
    {
        // ✅ 예외 처리: 게임이 시작되지 않았거나 넉백 중일 경우 이동 중지
        if (!MiniGameManager.IsGameStarted || isKnockback)
        {
            return;
        }

        // ⬅️➡️ 수평 이동 처리 (좌/우 방향키 입력)
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        planePhysics.ApplyHorizontalMovement(horizontalInput);

        // ⬇️ 중력 적용
        planePhysics.ApplyGravity();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 💥 적(Enemy)과 충돌 시 넉백 및 이펙트 처리
        if (other.CompareTag("Enemy"))
        {
            isKnockback = true;
            Invoke(nameof(EndKnockback), knockbackTime); // 일정 시간 후 넉백 해제

            // 🎯 충돌한 오브젝트의 속도 기반으로 넉백 강도 계산
            ObstacleMover mover = other.GetComponent<ObstacleMover>();
            float speed = mover != null ? mover.CurrentSpeed : 1f;
            float knockbackForce = Mathf.Clamp(speed * 1.5f, 3f, 10f);

            planePhysics.ApplyKnockback(other.transform.position, knockbackForce); // 💥 넉백 적용
            effectSpawner.SpawnEffect(transform.position); // ✨ 피격 이펙트 출력

            planePhysics.ReduceJumpForce(); // 🔻 점프력 약화
        }
    }

    /// <summary>
    /// ⏱ 넉백 상태 종료 → 이동 재개 가능
    /// </summary>
    private void EndKnockback()
    {
        isKnockback = false;
    }
}
