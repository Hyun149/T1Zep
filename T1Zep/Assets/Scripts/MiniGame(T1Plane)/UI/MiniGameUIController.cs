using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameUIController : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject miniGameUI;
    [SerializeField] private GameObject resultPanel;

    public void ShowStartButton() => startButton.SetActive(true);
    public void HideStartButton() => startButton.SetActive(false);

    public void ShowMiniGameUI() => miniGameUI.SetActive(true);
    public void HideMiniGameUI() => miniGameUI.SetActive(false);

    public void ShowResultPanel() => resultPanel.SetActive(true);
    public void HideResultPanel() => resultPanel.SetActive(false);
}
