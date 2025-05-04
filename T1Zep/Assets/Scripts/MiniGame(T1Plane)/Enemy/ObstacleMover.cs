using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float speedIncreaseRate = 1f;

    public float CurrentSpeed { get; private set; }

    private float spawnTime;

    private void Start()
    {
        spawnTime = Time.time;
    }

    void Update()
    {
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        float elapsed = Time.timeSinceLevelLoad;
        float currentSpeed = moveSpeed + (elapsed * speedIncreaseRate);

        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);

        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
}
