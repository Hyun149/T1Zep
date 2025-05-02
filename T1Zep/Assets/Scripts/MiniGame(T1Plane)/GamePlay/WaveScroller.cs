using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScroller : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.1f;
    private Material waveMaterial;
    private Vector2 offset;

    void Start()
    {
        waveMaterial = GetComponent<Renderer>().material;
        offset = waveMaterial.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        offset.x -= scrollSpeed * Time.deltaTime;
        waveMaterial.mainTextureOffset = offset;
    }
}
