using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 🖱 T1StackButtonHandler.cs
/// T1 스택 미니게임으로 씬을 전환하는 버튼 핸들러
/// - UI 버튼에서 호출되는 전용 메서드만 포함
/// </summary>
public class T1StackButtonHandler : MonoBehaviour
{
    /// <summary>
    /// ▶️ TStackScene으로 씬 전환 (스택 게임 시작)
    /// </summary>
    public void LoadStackScene()
    {
        SceneLoader.Load(SceneType.TStackScene);
    }
}
