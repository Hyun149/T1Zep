using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🖱 FlappyPlaneButtonHandler.cs
/// 비행기 미니게임 관련 UI 버튼의 동작을 처리하는 핸들러 클래스
/// - 씬 전환 및 게임 재시작/종료 호출을 담당
/// </summary>
public class FlappyPlaneButtonHandler : MonoBehaviour
{
    /// <summary>
    /// ▶️ [게임 시작] 버튼 클릭 시 비행기 미니게임 씬으로 전환
    /// </summary>
    public void OnClickStartMiniGame()
    {
        SceneLoader.Load(SceneType.TPlaneScene);
    }

    /// <summary>
    /// 🔁 [다시하기] 버튼 클릭 시 현재 미니게임 씬 재시작
    /// </summary>
    public void RetryMiniGame()
    {
        MiniGameManager.Instance.RestartGame();
    }

    /// <summary>
    /// 🔚 [종료] 버튼 클릭 시 메인 씬으로 돌아감
    /// </summary>
    public void ExitMiniGame()
    {
        SceneLoader.Load(SceneType.MainScene);
    }
}
