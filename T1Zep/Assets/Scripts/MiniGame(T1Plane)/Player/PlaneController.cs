using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
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
            planePhysics.ApplyJump(jumpForce);
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

        planePhysics.ApplyGravity();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            isKnockback = true;
            Invoke(nameof(EndKnockback), knockbackTime);

            planePhysics.ApplyKnockback(other.transform.position, 5f);
            effectSpawner.SpawnEffect(transform.position);
        }
    }

    private void EndKnockback()
    {
        isKnockback = false;
    }
}
