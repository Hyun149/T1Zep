using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private StackManager stackManager;
    [SerializeField] private float spawnInterval = 1.5f;

    private float timer = 0f;

    private void Start()
    {
        stackManager.Initialize(spawnPoints[0]);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnAndRegisterCube();
        }
    }

    public CubeMove SpawnCube(int spawnIndex)
    {
        Transform spawnPoint = spawnPoints[spawnIndex];
        Vector3 spawnPos = stackManager.GetNextSpawnPosition(spawnPoint.position);

        GameObject cube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);

        Vector3[] possibleDirs = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        Vector3 moveDir = possibleDirs[Random.Range(0, possibleDirs.Length)];

        CubeMove cubeMove = cube.GetComponent<CubeMove>();
        cubeMove.SetMoveDirection(moveDir);
        cubeMove.SetRandomSpeed();

        return cubeMove;
    }

    private void SpawnAndRegisterCube()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        CubeMove cube = SpawnCube(randomIndex);
        stackManager.SetCurrentCube(cube);
    }
}
