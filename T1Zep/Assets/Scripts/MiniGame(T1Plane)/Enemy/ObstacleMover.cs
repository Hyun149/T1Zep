using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🚧 ObstacleMover.cs
/// 장애물을 오른쪽 방향으로 이동시키고, 게임 진행 시간에 따라 속도를 점점 증가시킴
/// - 게임 시작 전에는 정지
/// - 일정 위치(X > 10f) 도달 시 오브젝트 제거
/// </summary>
public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;           // 🛫 기본 이동 속도
    [SerializeField] private float speedIncreaseRate = 1f;   // 🔺 시간 경과에 따른 속도 증가율

    public float CurrentSpeed { get; private set; }          // 🧭 현재 속도 (읽기 전용)

    private float spawnTime; // ⏱ 생성 시각 (사용 예정 가능성)

    private void Start()
    {
        spawnTime = Time.time; // ⏱ 생성된 시간 기록
    }

    private void Update()
    {
        // ✅ 예외 처리: 게임이 시작되지 않았다면 이동 중단
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        // 🕒 경과 시간 기반으로 현재 속도 계산
        float elapsed = Time.timeSinceLevelLoad;
        float currentSpeed = moveSpeed + (elapsed * speedIncreaseRate);

        // 👉 오른쪽 방향으로 이동 (X+ 방향)
        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);

        // ✅ 예외 처리: 화면 경계 밖으로 벗어나면 제거
        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
}
