using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🏹 ArrowProjectile.cs
/// 화살 발사체의 수명 관리 및 충돌 처리를 담당하는 클래스
/// - 큐브에 맞으면 점수 획득 후 양쪽 오브젝트 제거
/// </summary>
public class ArrowProjectile : MonoBehaviour
{
    private void Update()
    {
        // ⏱ 5초 후 자동 파괴 (명중하지 못한 경우 대비)
        Destroy(gameObject, 5f);
    }

    /// <summary>
    /// 🎯 충돌 처리 (T1Cube와 충돌 시 점수 + 제거)
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        // 🧊 'T1Cube' 태그를 가진 큐브에 맞았을 때
        if (other.CompareTag("T1Cube"))
        {
            StackScoreManager.Instance.AddScore(1); // ➕ 점수 1점 추가

            Destroy(other.gameObject); // 🎯 큐브 제거
            Destroy(this.gameObject);  // 🏹 화살 제거
        }
    }
}
