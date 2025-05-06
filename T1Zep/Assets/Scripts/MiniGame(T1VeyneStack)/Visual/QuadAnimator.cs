using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadAnimator : MonoBehaviour
{
    [SerializeField] private Material targetMaterial;
    [SerializeField] private Texture[] animationFrames;
    [SerializeField] private float frameRate = 10f;

    private int currentFrame = 0;
    private float timer = 0f;

    private void Update()
    {
        if (animationFrames.Length == 0)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer >= 1f / frameRate)
        {
            currentFrame = (currentFrame + 1) % animationFrames.Length;
            targetMaterial.mainTexture = animationFrames[currentFrame];
            timer = 0f;
        }
    }
}
