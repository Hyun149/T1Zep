using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandler
{
    private float current;
    private readonly float min;
    private readonly float decay;

    public JumpHandler(float baseForce, float decay, float min)
    {
        current = baseForce;
        this.decay = decay;
        this.min = min;
    }

    public float GetForce() => current;

    public void Reduce() => current = Mathf.Max(0f, current - decay);

    public void ResetJumpForce(float value) => current = value;
}
