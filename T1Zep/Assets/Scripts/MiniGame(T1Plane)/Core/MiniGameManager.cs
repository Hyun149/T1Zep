using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{

    [SerializeField] private MiniGameUIController uIController;
    [SerializeField] private Text scoreText;

    public static bool IsGameStarted = false;
    public static MiniGameManager Instance { get; private set; }

    private ScoreManager scoreManager;
    private Coroutine scoreRoutine;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

            scoreManager = new ScoreManager(scoreText);
    }

    public void StartGame()
    {
        IsGameStarted = true;
        scoreManager.ResetScore();
        StartCoroutine(GameSequence());

        scoreRoutine = StartCoroutine(AutoIncreaseScore());
    }

    private IEnumerator GameSequence()
    {
        uIController.ShowStartButton();
        yield return new WaitForSeconds(0.1f);
        uIController.HideStartButton();
        uIController.ShowMiniGameUI();

        // 미니게임 시작 (Enable Controller 등)

    }

    private IEnumerator AutoIncreaseScore()
    {
        while (IsGameStarted)
        {
            yield return new WaitForSeconds(1f);
            scoreManager.AddScore(1);
        }
    }

    public void EndGame(int score)
    {
        IsGameStarted = false;

        if (scoreRoutine != null)
        {
            StopCoroutine(scoreRoutine);
        }

        uIController.HideMiniGameUI();
        uIController.ShowResultPanel();
        uIController.ShowExitButton();
        Debug.Log($"최종점수: {scoreManager.GetScore()}");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        scoreManager.AddScore(score);
    }

    public int GetScore()
    {
        return scoreManager.GetScore();
    }
}
