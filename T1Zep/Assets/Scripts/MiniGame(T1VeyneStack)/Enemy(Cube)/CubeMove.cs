using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🧊 CubeMove.cs
/// 큐브 오브젝트를 설정된 방향으로 이동시키고,
/// 일정 시간이 지나면 자동 제거되는 이동 전용 스크립트
/// </summary>
public class CubeMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f; // 💨 기본 이동 속도

    private Vector3 moveDirection; // ➡️ 이동 방향
    private bool isMoving = true;  // ⏯ 이동 중 여부

    private void Start()
    {
        // ⏳ 30초 후 자동 제거 (오브젝트 풀링 미사용 시 메모리 누수 방지)
        Destroy(gameObject, 30f);
    }

    private void Update()
    {
        // ✅ 이동 중일 경우 지정된 방향으로 계속 이동
        if (isMoving)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    /// <summary>
    /// 🎯 외부에서 이동 방향 설정 (정규화 처리)
    /// </summary>
    public void SetMoveDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
        isMoving = true;
    }

    /// <summary>
    /// ⏹ 이동 정지 처리
    /// </summary>
    public void StopMoving()
    {
        isMoving = false;
    }

    /// <summary>
    /// 🎲 이동 속도를 1.5~3.5 사이로 랜덤 설정
    /// </summary>
    public void SetRandomSpeed()
    {
        moveSpeed = Random.Range(1.5f, 3.5f);
    }
}
