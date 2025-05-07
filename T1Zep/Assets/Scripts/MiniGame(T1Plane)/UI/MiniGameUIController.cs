using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 🖥 MiniGameUIController.cs
/// 미니게임 내 UI 요소들의 표시/숨김을 제어하는 전용 UI 컨트롤러
/// - 각 UI 오브젝트에 대해 Show/Hide 메서드를 제공
/// </summary>
public class MiniGameUIController : MonoBehaviour
{
    [SerializeField] private GameObject startButton;   // ▶️ 게임 시작 버튼
    [SerializeField] private GameObject currentScore;  // 📊 현재 점수 UI
    [SerializeField] private GameObject resultPanel;   // 🏁 결과 패널
    [SerializeField] private GameObject exitButton;    // ❌ 종료 버튼
    [SerializeField] private GameObject bestScore;     // 🏆 최고 점수 텍스트

    // ▶️ 시작 버튼 표시/숨김
    public void ShowStartButton() => startButton.SetActive(true);
    public void HideStartButton() => startButton.SetActive(false);

    // 📊 현재 점수 UI 표시/숨김
    public void ShowCurrentScore() => currentScore.SetActive(true);
    public void HideCurrentScore() => currentScore.SetActive(false);

    // 🏁 결과 패널 표시/숨김
    public void ShowResultPanel() => resultPanel.SetActive(true);
    public void HideResultPanel() => resultPanel.SetActive(false);

    // ❌ 종료 버튼 표시/숨김
    public void ShowExitButton() => exitButton.SetActive(true);
    public void HideExitButton() => exitButton.SetActive(false);

    // 🏆 최고 점수 텍스트 표시/숨김
    public void ShowBestScore() => bestScore.SetActive(true);
    public void HideBestScore() => bestScore.SetActive(false);
}
