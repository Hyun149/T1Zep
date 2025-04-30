using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void HandleInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
    }

    public void Move()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = moveInput.x * moveSpeed;

        if (rb.gravityScale == 0f)
        {
            velocity.y = moveInput.y * moveSpeed;
        }

        rb.velocity = velocity;
    }
}
