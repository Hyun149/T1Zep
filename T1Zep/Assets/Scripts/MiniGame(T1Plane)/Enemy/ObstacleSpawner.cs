using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float SpawnInterval = 2f;
    [SerializeField] private float spawnYMin = -4.5f;
    [SerializeField] private float spawnYMax = 4.5f;
    [SerializeField] private float spawnX = -10f;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= SpawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    void SpawnObstacle()
    {
        float ypos = Random.Range(spawnYMin, spawnYMax);
        Vector3 spawnPos = new Vector3(spawnX, ypos, 0);
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);
    }
}
