using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void Update()
    {
        int currentScore = StackScoreManager.Instance.GetScore();
        scoreText.text = $"Á¡¼ö: {currentScore}";
    }
}
