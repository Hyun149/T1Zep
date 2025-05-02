using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanePhysics : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float Gravity = 1f;
    [SerializeField] private float MaxY = 4.5f;
    private float verticalVelocity = 0f;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ApplyJump(float jumpForce)
    {
        verticalVelocity = jumpForce;
    }

    public void ApplyGravity()
    {
        verticalVelocity -= Gravity * Time.fixedDeltaTime;
        rb.velocity = new Vector2(0f, verticalVelocity);

        float clampedY = Mathf.Min(transform.position.y, MaxY);
        transform.position = new Vector2(transform.position.x, clampedY);

        if (transform.position.y >= MaxY)
        {
            verticalVelocity = 0f;
        }
    }

    public void ApplyKnockback(Vector2 from, float force)
    {
        Vector2 dir = ((Vector2)transform.position - from).normalized;
        rb.velocity = Vector2.zero;
        rb.velocity = dir * force;
    }
}
