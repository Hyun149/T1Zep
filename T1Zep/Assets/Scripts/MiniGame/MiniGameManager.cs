using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private GameObject miniGameUI;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject resultPanel;

    public void StartGame()
    {
        StartCoroutine(GameSequence());
    }

    private IEnumerator GameSequence()
    {
        startButton.SetActive(true);
        yield return new WaitForSeconds(2f);
        startButton.SetActive(false);
        miniGameUI.SetActive(true);

        // 미니게임 시작 (Enable Controller 등)

    }

    public void EndGame(int score)
    {
        miniGameUI.SetActive(false);
        resultPanel.SetActive(true);
        resultPanel.GetComponentInChildren<Text>().text = $"점수: {score}";
    }
}
