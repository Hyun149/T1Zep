using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [Header("Cube Setting")]
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Transform[] spawnPoints;

    private int spawnIndex = 0;
    private CubeMove currentCube;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentCube != null)
            {
                currentCube.StopMoving();
                currentCube = null;
            }
            else
            {
                SpawnCube();
            }
        }
    }

    private void SpawnCube()
    {
        Transform spawnPoint = spawnPoints[spawnIndex];
        GameObject cube = Instantiate(cubePrefab, spawnPoint.position, Quaternion.identity);

        Vector3 moveDir = (spawnIndex == 0) ? Vector3.back : spawnPoint.forward;

        CubeMove cubeMove = cube.GetComponent<CubeMove>();
        cubeMove.SetMoveDirection(moveDir);
        currentCube = cubeMove;

        cube.GetComponent<CubeMove>().SetMoveDirection(moveDir);

        spawnIndex = (spawnIndex + 1) % spawnPoints.Length;
    }
}
