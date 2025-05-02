using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StackManager : MonoBehaviour
{
    [SerializeField] private CubeSpawner cubeSpawner;

    private Transform lastCube;
    private float cubeHeight = 1f;
    private CubeMove currentCube;
    private int spawnIndex = 0;

    private void OnEnable()
    {
        InputHandler.OnSpacePressed += HandleSpaceInput;
    }

    private void OnDisable()
    {
        InputHandler.OnSpacePressed -= HandleSpaceInput;
    }

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

    private void HandleSpaceInput()
    {
        if (currentCube != null)
        {
            currentCube.StopMoving();

            TrimCube(currentCube.transform, lastCube);

            FixCube(currentCube.transform);
            currentCube = null;
        }
        else
        {
            currentCube = cubeSpawner.SpawnCube(spawnIndex);
            SetCurrentCube(currentCube);
            spawnIndex = (spawnIndex + 1) % 2;
        }
    }

    public void FixCube(Transform cube)
    {
        cube.position = new Vector3(cube.position.x, lastCube.position.y + cubeHeight, cube.position.z);
        lastCube = cube;
    }

    private void TrimCube(Transform current, Transform last)
    {
        float delta = current.position.x - last.position.x;
        float overhang = Mathf.Abs(delta);

        float cubeSize = last.localScale.x;

        if (overhang >= cubeSize)
        {
            Debug.Log("Miss - Game Over");
            return;
        }


        float newSize = cubeSize - overhang;
        float newPos = last.position.x + (delta / 2);

        current.localScale = new Vector3(newSize, 1, current.localScale.z);

        float overhangpos = current.position.x + (delta > 0 ? newSize / 2 : -newSize / 2);
        float overhangWidth = overhang;

        GameObject falling = GameObject.CreatePrimitive(PrimitiveType.Cube);
        falling.transform.localScale = new Vector3(overhangWidth, 1, current.localScale.z);
        falling.transform.position = new Vector3(overhangpos, current.position.y, current.position.z);
        falling.AddComponent<Rigidbody>();
    }
}
