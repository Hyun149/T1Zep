using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🏗 StackManager.cs
/// 큐브 쌓기 게임의 위치 계산 및 큐브 상태 관리 클래스
/// - 다음 큐브의 생성 위치 계산
/// - 현재 움직이는 큐브 등록
/// - 고정 시 큐브 위치를 조정하여 스택에 정렬
/// </summary>
public class StackManager : MonoBehaviour
{
    [SerializeField] private CubeSpawner cubeSpawner; // 🧊 큐브 생성기 연결

    private Transform lastCube;      // 📦 마지막으로 고정된 큐브
    private float cubeHeight = 1f;   // ⬆️ 한 층 높이
    private CubeMove currentCube;    // 🎯 현재 이동 중인 큐브

    /// <summary>
    /// 🛠 최초 시작 위치 설정 (기준 큐브 할당)
    /// </summary>
    public void Initialize(Transform baseCube)
    {
        lastCube = baseCube;
    }

    /// <summary>
    /// 📍 다음 큐브 생성 위치 반환 (마지막 큐브 위에 쌓음)
    /// </summary>
    public Vector3 GetNextSpawnPosition(Vector3 spawnOrigin)
    {
        return new Vector3(spawnOrigin.x, lastCube.position.y + cubeHeight, spawnOrigin.z);
    }

    /// <summary>
    /// 🎯 현재 생성된 큐브 등록 (움직이는 큐브 추적용)
    /// </summary>
    public void SetCurrentCube(CubeMove cube)
    {
        currentCube = cube;
    }

    /// <summary>
    /// 🧱 큐브를 정렬된 위치에 고정하고 스택 최상단으로 설정
    /// </summary>
    public void FixCube(Transform cube)
    {
        cube.position = new Vector3(cube.position.x, lastCube.position.y + cubeHeight, cube.position.z);
        lastCube = cube;
    }
}
