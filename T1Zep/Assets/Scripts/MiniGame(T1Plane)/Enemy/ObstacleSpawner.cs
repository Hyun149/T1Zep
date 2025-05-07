using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

/// <summary>
/// 🚧 ObstacleSpawner.cs
/// 일정 간격으로 장애물을 왼쪽(X) 위치에서 Y 좌표 랜덤으로 생성하는 스크립트
/// - 게임이 시작되었을 때만 동작
/// - 장애물은 ObstacleMover가 붙은 프리팹이어야 함
/// </summary>
public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab; // 🧱 생성할 장애물 프리팹
    [SerializeField] private float SpawnInterval = 2f;   // ⏱ 생성 간격 (초 단위)
    [SerializeField] private float spawnYMin = -4.5f;    // ⬇️ Y축 최소 위치
    [SerializeField] private float spawnYMax = 4.5f;     // ⬆️ Y축 최대 위치
    [SerializeField] private float spawnX = -10f;        // ➡️ 장애물 생성 위치의 X좌표 (고정된 왼쪽)

    private float timer; // ⏲ 장애물 생성 간격 체크용 타이머

    private void Update()
    {
        // ✅ 예외 처리: 게임이 시작되지 않았다면 생성 로직 중단
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        timer += Time.deltaTime;

        // ⏳ 설정된 간격마다 장애물 생성
        if (timer >= SpawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    /// <summary>
    /// 🎯 장애물을 좌측 X 고정 위치 + Y 랜덤 위치에 생성
    /// </summary>
    void SpawnObstacle()
    {
        float ypos = Random.Range(spawnYMin, spawnYMax);                  // 🎲 Y 위치 무작위 설정
        Vector3 spawnPos = new Vector3(spawnX, ypos, 0);                  // 📍 최종 생성 위치
        Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);       // 🧱 장애물 생성
    }
}
