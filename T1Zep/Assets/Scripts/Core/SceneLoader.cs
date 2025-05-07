using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 🌐 SceneLoader.cs
/// 씬 전환을 통합적으로 관리하는 유틸리티 클래스
/// - 문자열 대신 SceneType enum 사용으로 오타 및 유지보수 리스크 감소
/// - Load: 동기 로딩
/// - LoadAsync: 비동기 로딩 (로딩 화면과 함께 사용 가능)
/// </summary>
public static class SceneLoader
{
    /// <summary>
    /// 📥 동기 방식으로 씬을 로드합니다.
    /// </summary>
    /// <param name="scene">전환할 씬 타입</param>
    public static void Load(SceneType scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }

    /// <summary>
    /// 🔄 비동기 방식으로 씬을 로드합니다.
    /// 로딩 씬을 보여주거나 백그라운드 로딩이 필요한 경우에 사용합니다.
    /// </summary>
    /// <param name="scene">전환할 씬 타입</param>
    public static void LoadAsync(SceneType scene)
    {
        SceneManager.LoadSceneAsync(scene.ToString());
    }
}
