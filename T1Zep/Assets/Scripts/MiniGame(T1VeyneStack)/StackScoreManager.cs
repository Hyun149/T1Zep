using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackScoreManager : MonoBehaviour
{
    public static StackScoreManager Instance { get; private set; }

    private int currentScore = 0;

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

    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public int GetScore()
    {
        return currentScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
