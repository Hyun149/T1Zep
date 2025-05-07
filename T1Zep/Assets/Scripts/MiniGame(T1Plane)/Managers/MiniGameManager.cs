using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// 🎮 MiniGameManager.cs
/// 미니게임의 전반적인 흐름을 통제하는 게임 매니저 클래스
/// - 게임 시작/종료 관리
/// - 점수 증가 및 UI 반영
/// - 싱글턴 패턴 적용
/// </summary>
public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private MiniGameUIController uIController; // 🖥 UI 제어 담당 클래스
    [SerializeField] private Text scoreText;                    // 📊 현재 점수 출력 텍스트
    [SerializeField] private Text bestScoreText;                // 🏆 최고 점수 출력 텍스트

    public static bool IsGameStarted = false;                   // 🟢 게임 시작 상태 플래그
    public static MiniGameManager Instance { get; private set; } // 🧩 싱글턴 인스턴스

    private ScoreManager scoreManager;        // 📈 점수 계산 및 표시 관리 클래스
    private Coroutine scoreRoutine;           // ⏳ 자동 점수 증가용 코루틴 참조

    private void Awake()
    {
        // ✅ 싱글턴 인스턴스 할당
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // 중복 방지
        }

        // 🔧 점수 시스템 초기화
        scoreManager = new ScoreManager(scoreText, bestScoreText);
    }

    private void Start()
    {
        // 🏆 시작 시 최고 점수 불러와 UI에 반영
        int bestScore = ScoreSaveSystem.GetBestScore();
        bestScoreText.text = $"최고점수: {bestScore}";
    }

    /// <summary>
    /// ▶️ 미니게임 시작 처리: 상태 플래그 설정 및 UI/점수 초기화
    /// </summary>
    public void StartGame()
    {
        IsGameStarted = true;
        scoreManager.ResetScore();
        StartCoroutine(GameSequence());

        scoreRoutine = StartCoroutine(AutoIncreaseScore());
    }

    /// <summary>
    /// 🎬 게임 시작 UI 시퀀스: 버튼 숨기기, 점수 UI 표시
    /// </summary>
    private IEnumerator GameSequence()
    {
        uIController.ShowStartButton();
        yield return new WaitForSeconds(0.1f);
        uIController.HideStartButton();
        uIController.ShowCurrentScore();
        uIController.HideBestScore();

        // 미니게임 시작 시 필요한 로직 삽입 위치
    }

    /// <summary>
    /// ⏫ 게임이 시작된 동안 1초마다 점수를 1점씩 자동 증가
    /// </summary>
    private IEnumerator AutoIncreaseScore()
    {
        while (IsGameStarted)
        {
            yield return new WaitForSeconds(1f);
            scoreManager.AddScore(1);
        }
    }

    /// <summary>
    /// 🛑 게임 종료 처리: 코루틴 정지, UI 갱신, 점수 반영
    /// </summary>
    public void EndGame()
    {
        IsGameStarted = false;

        if (scoreRoutine != null)
        {
            StopCoroutine(scoreRoutine);
        }

        scoreManager.FinalizeScore();

        uIController.HideCurrentScore();
        uIController.ShowResultPanel();
        uIController.ShowExitButton();
        uIController.ShowBestScore();
    }

    /// <summary>
    /// 🔁 현재 씬 다시 로딩하여 게임 재시작
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// ➕ 점수를 외부에서 수동으로 추가
    /// </summary>
    public void AddScore(int score)
    {
        scoreManager.AddScore(score);
    }

    /// <summary>
    /// 📤 현재 점수 조회
    /// </summary>
    public int GetScore()
    {
        return scoreManager.GetScore();
    }
}
