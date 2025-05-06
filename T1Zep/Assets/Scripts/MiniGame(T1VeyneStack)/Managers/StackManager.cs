using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private CubeSpawner cubeSpawner;

    private Transform lastCube;
    private float cubeHeight = 1f;
    private CubeMove currentCube;


    public void Initialize(Transform baseCube)
    {
        lastCube = baseCube;
    }

    public Vector3 GetNextSpawnPosition(Vector3 spawnOrigin)
    {
        return new Vector3(spawnOrigin.x, lastCube.position.y + cubeHeight, spawnOrigin.z);
    }

    public void SetCurrentCube(CubeMove cube)
    {
        currentCube = cube;
    }

    public void FixCube(Transform cube)
    {
        cube.position = new Vector3(cube.position.x, lastCube.position.y + cubeHeight, cube.position.z);
        lastCube = cube;
    }  
}
