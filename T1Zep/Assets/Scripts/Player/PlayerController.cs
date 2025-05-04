using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private PlayerInputHandler inputHandler;

    private PlayerJump jumper;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<PlayerInputHandler>();
        movement = GetComponent<PlayerMovement>();
        jumper = GetComponent<PlayerJump>();

        movement.Initialize(rb);
        jumper.Initialize(rb);
    }

    void Update()
    {
        inputHandler.ProcessInput();

        if (inputHandler.JumpPressed)
        {
            jumper.RequestJump();
        }

        movement.Move(inputHandler.MoveInput);

        HandleFlip(inputHandler.MoveInput.x);
    }

    private void FixedUpdate()
    {
        jumper.CheckLanding();
    }

    private void HandleFlip(float horizontal)
    {
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
