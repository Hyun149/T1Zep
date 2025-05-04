using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private PlayerAnimator playerAnimator;

    public Vector2 MoveInput { get; private set; }
    public bool JumpPressed { get; private set; }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        bool isRunning = Mathf.Abs(horizontal) > 0.01f;
        playerAnimator.UpdateRunning(isRunning);
    }

    public void ProcessInput()
    {
        MoveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        JumpPressed = Input.GetKeyDown(KeyCode.Space);
    }
}
