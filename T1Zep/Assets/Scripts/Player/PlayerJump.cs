using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float flapForce = 15.0f;

    private Rigidbody2D rb;
    private float jumpStartY;
    private bool isJumping;
    private bool canJump;

    public void Initialize(Rigidbody2D rigidbody)
    {
        rb = rigidbody;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
        StartCoroutine(EnableJump());
    }

    private IEnumerator EnableJump()
    {
        yield return new WaitForSeconds(0.1f);
        canJump = true;
    }

    public bool IsJumping => isJumping;

    public void RequestJump()
    {
        if (!canJump || isJumping) return;

        rb.gravityScale = 1f;
        jumpStartY = transform.position.y;
        rb.velocity = new Vector2(rb.velocity.x, flapForce);
        isJumping = true;
    }

    public void CheckLanding()
    {       
        if (isJumping && rb.velocity.y <= 0f && transform.position.y <= jumpStartY)
        {
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;
            transform.position = new Vector3(transform.position.x, jumpStartY, transform.position.z);
            isJumping = false;
            Debug.Log("✅ 점프 후 복귀 착지 완료");
        }
    }
}
