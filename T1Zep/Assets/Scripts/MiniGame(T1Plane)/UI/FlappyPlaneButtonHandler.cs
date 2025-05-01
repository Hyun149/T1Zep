using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlaneButtonHandler : MonoBehaviour
{
    public void OnClickStartMiniGame()
    {
        SceneLoader.Load(SceneType.FlappyPlaneScene);
    }
}
