using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 🌊 WaveScroller.cs
/// 머티리얼의 텍스처 오프셋을 이동시켜 파도처럼 흐르는 시각 효과를 구현
/// - 주로 물, 흐름, 배경 등에서 사용
/// </summary>
public class WaveScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.1f; // 💨 텍스처가 흐르는 속도

    private Material waveMaterial; // 🎨 적용된 머티리얼
    private Vector2 offset;        // 🔁 현재 텍스처 오프셋 값

    private void Start()
    {
        waveMaterial = GetComponent<Renderer>().material;   // 🎯 현재 렌더러의 머티리얼 참조
        offset = waveMaterial.mainTextureOffset;           // 📦 초기 오프셋 저장
    }

    private void Update()
    {
        // ⬅️ 왼쪽 방향으로 텍스처를 조금씩 이동시켜 흐름 느낌을 연출
        offset.x -= scrollSpeed * Time.deltaTime;

        // 🎨 머티리얼에 새로운 오프셋 적용
        waveMaterial.mainTextureOffset = offset;
    }
}
