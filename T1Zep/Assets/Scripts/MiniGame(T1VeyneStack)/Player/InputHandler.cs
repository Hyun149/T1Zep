using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ⌨️ InputHandler.cs
/// 게임 시작 시 Space 키 입력을 감지하여 일정 간격으로 화살을 발사하는 입력 처리 클래스
/// - 게임 상태 확인
/// - 연사 방지 쿨다운 적용
/// </summary>
public class InputHandler : MonoBehaviour
{
    private float lastShootTime = -999f; // 🕒 마지막 발사 시각 (초기값은 과거로 설정)

    [SerializeField] private ArrowShooter arrowShooter;   // 🏹 화살 발사기
    [SerializeField] private float shootCooldown = 0.3f;   // ⏱ 발사 간격 제한 (초)

    private void Update()
    {
        // ✅ 게임이 시작되지 않았으면 입력 무시
        if (T1StackGameManager.Instance == null || !T1StackGameManager.Instance.IsGameStarted())
        {
            return;
        }

        // ⌨️ Space 키 입력 감지
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ⏳ 마지막 발사 이후 쿨다운 미충족 시 발사 금지
            if (Time.time - lastShootTime < shootCooldown)
            {
                return;
            }

            // 🔫 발사 시각 갱신 및 화살 발사
            lastShootTime = Time.time;
            arrowShooter.ShootArrow();
        }
    }
}
