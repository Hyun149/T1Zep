using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameUIController : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject currentScore;
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject bestScore;

    public void ShowStartButton() => startButton.SetActive(true);
    public void HideStartButton() => startButton.SetActive(false);

    public void ShowCurrentScore() => currentScore.SetActive(true);
    public void HideCurrentScore() => currentScore.SetActive(false);

    public void ShowResultPanel() => resultPanel.SetActive(true);
    public void HideResultPanel() => resultPanel.SetActive(false);

    public void ShowExitButton() => exitButton.SetActive(true);
    public void HideExitButton() => exitButton.SetActive(false);

    public void ShowBestScore() => bestScore.SetActive(true);
    public void HideBestScore() => bestScore.SetActive(false);
}
