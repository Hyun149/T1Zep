using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1StackGameManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private CubeSpawner cubeSpawner;
    [SerializeField] private GameObject canvas;

    public static T1StackGameManager Instance { get; private set; }

    private bool isGameStarted = false;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        if (canvas != null)
        {
            canvas.SetActive(true);
        }
        else
        {
            Debug.Log("Canvas가 연결되지 않았습니다.");
        }

        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        isGameStarted = true;
        StackScoreManager.Instance.ResetScore();

        if (startButton != null)
        {
            startButton.SetActive(false);
        }
        
        Time.timeScale = 1f;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}
