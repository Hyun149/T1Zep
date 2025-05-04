using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanePhysics : MonoBehaviour
{
    [SerializeField] private float Gravity = 1f;
    [SerializeField] private float MaxY = 4.5f;
    [SerializeField] private float baseJumpForce = 5f;
    [SerializeField] private float jumpDecay = 0.5f;
    [SerializeField] private float minJumpForce = 2f;
    [SerializeField] private float horizontalSpeed = 3f;

    private Rigidbody2D rb;
    private float verticalVelocity = 0f;
    private JumpHandler jumpHandler;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        jumpHandler = new JumpHandler(baseJumpForce, jumpDecay, minJumpForce);
    }

    public void ApplyJump()
    {
        verticalVelocity = jumpHandler.GetForce();
    }

    public void ApplyGravity()
    {
        verticalVelocity -= Gravity * Time.fixedDeltaTime;

        Vector2 velocity = rb.velocity;
        velocity.y = verticalVelocity;
        rb.velocity = velocity;

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

    public void ApplyHorizontalMovement(float input)
    {
        Vector2 velocity = rb.velocity;
        velocity.x = input * horizontalSpeed;
        rb.velocity = velocity;
    }

    public void ReduceJumpForce()
    {
        jumpHandler.Reduce();
    }
}
