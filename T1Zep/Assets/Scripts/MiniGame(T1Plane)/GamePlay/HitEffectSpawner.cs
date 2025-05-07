using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 💥 HitEffectSpawner.cs
/// 피격 이펙트(예: 폭발, 충돌 등)를 특정 위치에 생성하고 일정 시간 후 제거하는 유틸리티
/// </summary>
public class HitEffectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject hitEffectPrefab; // 💫 생성할 피격 이펙트 프리팹

    /// <summary>
    /// 🎯 지정된 위치에 이펙트를 생성하고, 1초 후 자동 제거
    /// </summary>
    /// <param name="position">이펙트를 생성할 위치</param>
    public void SpawnEffect(Vector2 position)
    {
        // ✅ 예외 처리: 이펙트 프리팹이 설정되어 있을 때만 실행
        if (hitEffectPrefab != null)
        {
            GameObject fx = Instantiate(hitEffectPrefab, position, Quaternion.identity); // ✨ 이펙트 생성
            Destroy(fx, 1.0f); // ⏳ 1초 뒤 자동 제거
        }
    }
}
