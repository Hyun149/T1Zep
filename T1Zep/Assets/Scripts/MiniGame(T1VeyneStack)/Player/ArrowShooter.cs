using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🏹 ArrowShooter.cs
/// 화살을 지정된 위치에서 생성하고, 물리 속도를 이용해 발사하는 클래스
/// - firePoint 기준으로 방향 설정
/// - Rigidbody를 통해 속도 적용
/// </summary>
public class ArrowShooter : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;    // 🏹 생성할 화살 프리팹
    [SerializeField] private Transform firePoint;       // 🔫 화살이 나갈 위치 및 방향 기준
    [SerializeField] private float shootForce = 20f;    // 💨 화살 발사 속도

    /// <summary>
    /// 🔫 화살을 firePoint 위치에서 생성 후 발사
    /// </summary>
    public void ShootArrow()
    {
        // 🏹 화살 인스턴스 생성
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        // 💥 Rigidbody에 속도 적용
        Rigidbody rb = arrow.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.right * shootForce; // ➡️ 오른쪽 방향으로 발사
        }
        else
        {
            Debug.LogWarning("RigidBody가 프리펩에 없습니다!"); // ⚠️ 예외 처리
        }
    }
}
