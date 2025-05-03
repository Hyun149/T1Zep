using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T1StackGameManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private CubeSpawner cubeSpawner;

    public static T1StackGameManager Instance { get; private set; }

    private bool isGameStarted = false;

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
    }

    void Start()
    {
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        isGameStarted = true;
        StackScoreManager.Instance.ResetScore();
        startButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public bool IsGameStarted()
    {
        return isGameStarted;
    }
}
