using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🧱 CubeSpawner.cs
/// 주기적으로 큐브를 생성하고, StackManager를 통해 위치를 계산 및 등록하는 큐브 스포너
/// - 랜덤한 위치에서 생성
/// - 이동 방향 및 속도도 무작위 설정
/// </summary>
public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;         // 🧊 생성할 큐브 프리팹
    [SerializeField] private Transform[] spawnPoints;       // 📍 큐브 생성 위치 배열
    [SerializeField] private StackManager stackManager;     // 🏗 큐브 쌓기 위치 계산기
    [SerializeField] private float spawnInterval = 1.5f;    // ⏱ 생성 간격

    private float timer = 0f;

    private void Start()
    {
        // 🛠 게임 시작 시 첫 기준 위치 설정 (StackManager에 첫 스폰 포인트 전달)
        stackManager.Initialize(spawnPoints[0]);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        // 📦 주기적으로 큐브 생성
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnAndRegisterCube();
        }
    }

    /// <summary>
    /// 🎯 특정 인덱스의 스폰 위치에서 큐브를 생성하고 이동 방향/속도 설정
    /// </summary>
    public CubeMove SpawnCube(int spawnIndex)
    {
        Transform spawnPoint = spawnPoints[spawnIndex];
        Vector3 spawnPos = stackManager.GetNextSpawnPosition(spawnPoint.position); // 🧮 스택 상단 위치 계산

        GameObject cube = Instantiate(cubePrefab, spawnPos, Quaternion.identity); // 🧊 큐브 생성

        // 🎲 랜덤 이동 방향 설정 (전/후/좌/우)
        Vector3[] possibleDirs = { Vector3.forward, Vector3.back, Vector3.left, Vector3.right };
        Vector3 moveDir = possibleDirs[Random.Range(0, possibleDirs.Length)];

        CubeMove cubeMove = cube.GetComponent<CubeMove>();
        cubeMove.SetMoveDirection(moveDir);   // ➡️ 방향 지정
        cubeMove.SetRandomSpeed();            // 💨 속도 무작위

        return cubeMove;
    }

    /// <summary>
    /// 📦 큐브를 생성하고 StackManager에 현재 큐브로 등록
    /// </summary>
    private void SpawnAndRegisterCube()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);     // 📍 스폰 위치 랜덤 선택
        CubeMove cube = SpawnCube(randomIndex);                    // 🧊 큐브 생성 및 세팅
        stackManager.SetCurrentCube(cube);                         // 🧱 스택 매니저에 등록
    }
}
