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

    private ScoreManger scoreManger;

    private void Awake()
    {
        scoreManger = new ScoreManger(scoreText);
    }

    public void StartGame()
    {
        IsGameStarted = true;
        scoreManger.ResetScore();
        StartCoroutine(GameSequence());
    }

    private IEnumerator GameSequence()
    {
        uIController.ShowStartButton();
        yield return new WaitForSeconds(0.1f);
        uIController.HideStartButton();
        uIController.ShowMiniGameUI();

        // �̴ϰ��� ���� (Enable Controller ��)

    }

    public void EndGame(int score)
    {
        uIController.HideMiniGameUI();
        uIController.ShowResultPanel();
        Debug.Log($"��������: {scoreManger.GetScore()}");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int score)
    {
        scoreManger.AddScore(score);
    }
}
