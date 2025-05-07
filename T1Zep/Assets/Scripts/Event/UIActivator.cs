using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 📺 UIActivator.cs
/// 다수의 UI 오브젝트(targets)를 일괄적으로 활성화하거나 비활성화하는 유틸리티
/// - 외부 트리거에서 Activate/Deactivate 호출
/// </summary>
public class UIActivator : MonoBehaviour
{
    [SerializeField] private GameObject[] targets; // ✅ 활성화/비활성화 대상 UI 오브젝트 배열

    /// <summary>
    /// ✅ 모든 target을 활성화 상태로 설정
    /// </summary>
    public void Activate()
    {
        SetActiveAll(true);
    }

    /// <summary>
    /// ✅ 모든 target을 비활성화 상태로 설정
    /// </summary>
    public void Deactivate()
    {
        SetActiveAll(false);
    }

    /// <summary>
    /// 🎯 전달된 상태(state)에 따라 전체 target을 SetActive 처리
    /// </summary>
    private void SetActiveAll(bool state)
    {
        foreach (GameObject target in targets)
        {
            if (target != null) // ✅ null 예외 처리
            {
                target.SetActive(state);
            }
        }
    }
}
