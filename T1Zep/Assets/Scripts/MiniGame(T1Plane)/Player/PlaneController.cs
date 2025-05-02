using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    private MiniGameManager miniGameManager;

    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 1f;
    [SerializeField] private float minY = -4.5f;
    [SerializeField] private float maxY = 4.5f;

    private float verticalVelocity = 0f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    private void Start()
    {
        miniGameManager = FindObjectOfType<MiniGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        HandleJumpInput();
        CheckGameOver();
    }

    private void HandleJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            verticalVelocity = jumpForce;
        }
    }

    private void CheckGameOver()
    {
        if (transform.position.x > 10f)
        {
            MiniGameManager.Instance.EndGame();
        }
    }

    private void FixedUpdate()
    {
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        verticalVelocity -= gravity * Time.fixedDeltaTime;
        rb.velocity = new Vector2(0f, verticalVelocity);

        float ClampedY = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector2(transform.position.x, ClampedY);

        if (transform.position.y <= minY || transform.position.y >= maxY)
        {
            verticalVelocity = 0f;
        }
    }


}
