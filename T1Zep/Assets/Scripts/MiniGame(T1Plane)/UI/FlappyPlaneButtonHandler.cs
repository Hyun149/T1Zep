using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlaneButtonHandler : MonoBehaviour
{
    public void OnClickStartMiniGame()
    {
        SceneLoader.Load(SceneType.TPlaneScene);
    }

    public void RetryMiniGame()
    {
        MiniGameManager.Instance.RestartGame();
    }

    public void ExitMiniGame()
    {
        SceneLoader.Load(SceneType.MainScene);
    }
}
