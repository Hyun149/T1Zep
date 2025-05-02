using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private StackManager stackManager;

    private int spawnIndex = 0;
    private CubeMove currentCube;

    private void Start()
    {
        stackManager.Initialize(GameObject.Find("MainCube").transform);
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
}
