using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🎬 SceneType.cs
/// 프로젝트에서 사용하는 씬 이름을 Enum으로 정의
/// - 문자열 직접 입력을 피하고 오타 방지
/// - SceneLoader에서 사용하여 타입 안정성 확보
/// </summary>
public enum SceneType
{
    MainScene,     // 🏠 메인 메뉴 씬
    TPlaneScene,   // ✈️ 비행 미니게임 씬
    TStackScene    // 🧱 스택 쌓기 미니게임 씬
}