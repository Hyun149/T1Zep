using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    public void Initialize(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
    }

    public void Move(Vector2 input)
    {
        Vector2 velocity = rb.velocity;
        velocity.x = input.x * moveSpeed;

        if (rb.gravityScale == 0f)
        {
            velocity.y = input.y * moveSpeed;
        }

        rb.velocity = velocity;
    }
}
