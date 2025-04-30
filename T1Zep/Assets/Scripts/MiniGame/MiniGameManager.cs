using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    [SerializeField] private GameObject miniGameUI;
    [SerializeField] private GameObject introPanel;
    [SerializeField] private GameObject resultPanel;

    void StartGame()
    {
        StartCoroutine(GameSequence());
    }

    private IEnumerator GameSequence()
    {
        introPanel.SetActive(true);
        yield return new WaitForSeconds(2f);
        introPanel.SetActive(false);
        miniGameUI.SetActive(true);

        // �̴ϰ��� ���� (Enable Controller ��)

    }

    public void EndGame(int score)
    {
        miniGameUI.SetActive(false);
        resultPanel.SetActive(true);
        resultPanel.GetComponentInChildren<Text>().text = $"����: {score}";
    }
}
