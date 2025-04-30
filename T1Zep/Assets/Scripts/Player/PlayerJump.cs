using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float flapForce = 15.0f;

    private Rigidbody2D rb;
    private bool isFlap;
    private float jumpStartY = 0f;
    private bool isJumping = false;
    private bool canJump = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator Start()
    {
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;

        // 초기 프레임 중력 영향 방지 및 안정화 
        yield return new WaitForSeconds(0.1f);
        canJump = true;
    }

    private void Update()
    {
        if (canJump && Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isFlap = true;
        }
    }

    private void FixedUpdate()
    {
        JumpIfRequested();
        CheckLanding();
    }

    public void JumpIfRequested()
    {
        if (!isFlap) return;
        {
            rb.gravityScale = 1f;
            jumpStartY = transform.position.y;
            rb.velocity = new Vector2(rb.velocity.x, flapForce);

            isJumping = true;
            isFlap = false;
        }
    }

    private void CheckLanding()
    {       
        if (isJumping && rb.velocity.y <= 0f && transform.position.y <= jumpStartY)
        {
            rb.gravityScale = 0f;
            rb.velocity = Vector2.zero;

            Vector3 pos = transform.position;
            pos.y = jumpStartY;
            transform.position = pos;
           
            isJumping = false;
            Debug.Log("✅ 점프 후 복귀 착지 완료");
        }
    }
}
