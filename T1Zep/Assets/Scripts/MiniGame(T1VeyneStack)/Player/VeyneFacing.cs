using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 👤 VeyneFacing.cs
/// 캐릭터 이동 방향에 따라 모델을 좌우로 반전(Flip)시키는 전용 클래스
/// - 좌/우 이동에 따라 y축 회전값을 조정
/// </summary>
public class VeyneFacing : MonoBehaviour
{
    [SerializeField] private Transform characterModel; // 👕 회전시킬 캐릭터 모델 Transform
    private bool isFacingRight = true;                 // ▶️ 현재 오른쪽을 바라보고 있는지 여부

    /// <summary>
    /// ↔️ 이동 방향에 따라 회전 필요 여부를 판단하고 Flip 실행
    /// </summary>
    /// <param name="moveDir">이동 방향 벡터</param>
    public void UpdateFacing(Vector3 moveDir)
    {
        // ➡️ 오른쪽 이동인데 왼쪽을 보고 있다면 → 반전
        if (moveDir.x > 0 && !isFacingRight)
        {
            Flip();
        }
        // ⬅️ 왼쪽 이동인데 오른쪽을 보고 있다면 → 반전
        else if (moveDir.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    /// <summary>
    /// ↩️ 캐릭터 좌우 반전 (y축 회전값을 0 ↔ 180으로 변경)
    /// </summary>
    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 angles = characterModel.localEulerAngles;
        angles.y = isFacingRight ? 0f : 180f;  // 좌우 반전 처리
        characterModel.localEulerAngles = angles;
    }
}
