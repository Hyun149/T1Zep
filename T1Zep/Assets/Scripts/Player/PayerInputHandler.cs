using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ⌨️ PlayerInputHandler.cs
/// 플레이어 이동 및 점프 입력을 처리하고, 애니메이터와 상태를 동기화하는 클래스
/// - 외부에서 호출 가능한 입력 처리 함수 제공
/// </summary>
public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerAnimator playerAnimator; // 🎞 이동 애니메이션을 제어할 애니메이터

    public Vector2 MoveInput { get; private set; }  // ↔️ 현재 이동 입력 값 (외부 접근 가능)
    public bool JumpPressed { get; private set; }   // ⬆️ 점프 입력 여부 (Space 키)

    private void Update()
    {
        // 🎮 좌우 입력 감지 후 달리는 상태 전달
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool isRunning = Mathf.Abs(horizontal) > 0.01f;
        playerAnimator.UpdateRunning(isRunning); // 🎞 애니메이션 상태 변경
    }

    /// <summary>
    /// 🎮 입력값을 외부에서 호출 시 처리 (MoveInput, JumpPressed 업데이트)
    /// </summary>
    public void ProcessInput()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        JumpPressed = Input.GetKeyDown(KeyCode.Space);
    }
}
