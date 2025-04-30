using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private PlayerInputHandler inputHandler;
    private PlayerMovement movement;
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
    }

    private void FixedUpdate()
    {
        jumper.CheckLanding();
    }
}
