using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float knockbackTime = 0.3f;

    private bool isKnockback = false;

    private MiniGameManager miniGameManager;
    private PlanePhysics planePhysics;
    private HitEffectSpawner effectSpawner;
    private GameOverChecker gameOverChecker;


    private void Awake()
    {
        miniGameManager = FindObjectOfType<MiniGameManager>();
        planePhysics = GetComponent<PlanePhysics>();
        effectSpawner = GetComponent<HitEffectSpawner>();
        gameOverChecker = GetComponent<GameOverChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            planePhysics.ApplyJump();
        }

        if (gameOverChecker.IsOutOfBounds(transform.position))
        {
            MiniGameManager.Instance.EndGame();
        }
    }

    private void FixedUpdate()
    {
        if (!MiniGameManager.IsGameStarted || isKnockback)
        {
            return;
        }

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        planePhysics.ApplyHorizontalMovement(horizontalInput);

        planePhysics.ApplyGravity();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isKnockback = true;
            Invoke(nameof(EndKnockback), knockbackTime);

            ObstacleMover mover = other.GetComponent<ObstacleMover>();
            float speed = mover != null ? mover.CurrentSpeed : 1f;
            float knockbackForce = Mathf.Clamp(speed * 1.5f, 3f, 10f);

            planePhysics.ApplyKnockback(other.transform.position, knockbackForce);
            effectSpawner.SpawnEffect(transform.position);

            planePhysics.ReduceJumpForce();
        }
    }

    private void EndKnockback()
    {
        isKnockback = false;
    }
}
