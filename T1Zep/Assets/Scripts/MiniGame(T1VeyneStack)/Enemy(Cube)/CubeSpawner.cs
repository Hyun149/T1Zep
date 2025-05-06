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
    private int spawnIndex = 0;

    private void Start()
    {
        stackManager.Initialize(GameObject.Find("MainCube").transform);
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

        GameObject cube = Instantiate(cubePrefab, spawnPoint.position, Quaternion.identity);
        Vector3 moveDir = (spawnIndex == 0) ? Vector3.back : spawnPoint.forward;

        CubeMove cubeMove = cube.GetComponent<CubeMove>();
        cubeMove.SetMoveDirection(moveDir);

        return cubeMove;
    }

    private void SpawnAndRegisterCube()
    {
        CubeMove cube = SpawnCube(spawnIndex);
        stackManager.SetCurrentCube(cube);
        spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
    }
}
