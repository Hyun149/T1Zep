using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🚶‍♂️ VeyneMove.cs
/// 캐릭터의 평면 이동, 회전 방향 처리, 시선 방향 제어까지 담당하는 이동 컨트롤러
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class VeyneMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;                   // 💨 이동 속도
    [SerializeField] private Transform firePoint;                    // 🎯 발사 방향 기준 오브젝트
    [SerializeField] private VeyneFacing facingController;           // 👤 캐릭터 좌우 시선 전환 컨트롤러

    private Rigidbody rb;
    private float fixedY;                                            // ⬆️ y축 고정값
    private Vector3 lastDirection = Vector3.forward;                 // ↔️ 마지막 이동 방향

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fixedY = transform.position.y; // y축 고정값 저장 (중력/튐 방지)
    }

    private void Start()
    {
        // ⚠️ 예외 처리: FacingController 연결 여부 확인
        if (facingController == null)
        {
            Debug.Log("facingController가 연결되지 않았습니다!");
        }
    }

    private void Update()
    {
        // 🎮 이동 입력 처리 (WASD, 방향키 등)
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(inputX, 0f, inputZ).normalized;

        if (direction != Vector3.zero)
        {
            // 🧭 마지막 이동 방향 저장 및 회전 각도 계산
            lastDirection = direction;
            float angle = Mathf.Atan2(lastDirection.z, lastDirection.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, -angle, 0); // 🔫 발사 방향 회전

            facingController.UpdateFacing(direction); // 👤 좌우 방향 전환
        }

        // 🛞 Rigidbody를 통한 이동 처리
        Vector3 velocity = direction * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

        // ⬇️ y축 위치 고정 처리 (지면에 고정)
        Vector3 pos = transform.position;
        pos.y = fixedY;
        transform.position = pos;
    }
}
