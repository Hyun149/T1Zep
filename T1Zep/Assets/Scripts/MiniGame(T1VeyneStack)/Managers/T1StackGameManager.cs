using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🎮 T1StackGameManager.cs
/// T1 스택 미니게임의 전반적인 흐름을 제어하는 게임 매니저
/// - 게임 시작/중지 상태 관리
/// - UI 버튼, 캔버스 활성화
/// - Time.timeScale로 게임 일시 정지/재개 처리
/// </summary>
public class T1StackGameManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;     // ▶️ 게임 시작 버튼
    [SerializeField] private CubeSpawner cubeSpawner;    // 🧊 큐브 생성기
    [SerializeField] private GameObject canvas;          // 🖼 전체 UI 캔버스

    public static T1StackGameManager Instance { get; private set; } // 🌐 싱글턴 인스턴스

    private bool isGameStarted = false; // ▶️ 게임 시작 여부 상태값

    private void Awake()
    {
        // ✅ 싱글턴 인스턴스 할당
        Instance = this;
    }

    private void Start()
    {
        // 🖼 캔버스 활성화 여부 확인
        if (canvas != null)
        {
            canvas.SetActive(true); // UI 표시
        }
        else
        {
            Debug.Log("Canvas가 연결되지 않았습니다."); // ⚠️ 예외 처리: 누락 경고
        }

        // ⏸ 게임 시작 전 일시 정지
        Time.timeScale = 0f;
    }

    /// <summary>
    /// ▶️ 게임 시작 처리
    /// - 점수 초기화
    /// - 시작 버튼 숨김
    /// - 시간 흐름 재개
    /// </summary>
    public void StartGame()
    {
        isGameStarted = true;

        StackScoreManager.Instance.ResetScore(); // 점수 초기화

        if (startButton != null)
        {
            startButton.SetActive(false); // 시작 버튼 숨김
        }

        Time.timeScale = 1f; // 게임 재개
    }

    /// <summary>
    /// 📍 게임이 시작되었는지 여부 반환
    /// </summary>
    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}
