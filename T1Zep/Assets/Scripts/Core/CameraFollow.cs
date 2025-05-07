using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🎥 CameraFollow.cs
/// 플레이어 등의 타겟을 부드럽게 따라가는 카메라 스크립트
/// - 경계 범위(minBounds ~ maxBounds) 내에서만 이동
/// - LateUpdate 사용으로 타겟 이동 후 위치 보정
/// </summary>
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;         // 📍 따라갈 대상 (예: 플레이어)
    [SerializeField] private float smoothSpeed = 0.12f; // 💨 따라가는 속도 (Lerp 보간)
    [SerializeField] private Vector2 minBounds;         // ⛔ 카메라 이동 최소 위치 제한
    [SerializeField] private Vector2 maxBounds;         // ⛔ 카메라 이동 최대 위치 제한

    private void LateUpdate()
    {
        // ✅ 예외 처리 1: 타겟이 지정되지 않은 경우 처리
        if (target == null)
        {
            // 타겟이 없으면 위치 이동하지 않음
            return;
        }

        // 📌 타겟 위치 기준으로 이동 목표 계산
        Vector3 desiredPosition = target.position;

        // ✅ 카메라 이동 범위 제한 (X, Y)
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

        // 📏 Z축 고정 (카메라 깊이 값 유지)
        desiredPosition.z = transform.position.z;

        // 🔄 부드럽게 위치 보간하여 이동
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    }
}
