using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 1f;

    private float vericalVelocity = 0f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            vericalVelocity = jumpForce;
        }
    }

    private void FixedUpdate()
    {
        vericalVelocity -= gravity * Time.fixedDeltaTime;
        Vector2 movement = new Vector2(-moveSpeed, vericalVelocity);
        rb.velocity = movement;
    }


}
