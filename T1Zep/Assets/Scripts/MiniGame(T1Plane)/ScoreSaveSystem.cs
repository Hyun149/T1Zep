using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSaveSystem : MonoBehaviour
{
    private const string BestScoreKey = "BestScore";

    public static void SaveScore(int score)
    {
        int bestScore = GetBestScore();

        if (score > bestScore)
        {
            PlayerPrefs.SetInt(BestScoreKey, score);
            PlayerPrefs.Save();
        }
    }

    public static int GetBestScore()
    {
        return PlayerPrefs.GetInt(BestScoreKey, 0);
    }
}
