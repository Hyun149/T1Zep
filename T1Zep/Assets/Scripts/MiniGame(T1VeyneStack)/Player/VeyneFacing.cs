using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeyneFacing : MonoBehaviour
{
    [SerializeField] private Transform characterModel;
    private bool isFacingRight = true;

    public void UpdateFacing(Vector3 moveDir)
    {
        if (moveDir.x > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (moveDir.x < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 angles = characterModel.localEulerAngles;
        angles.y = isFacingRight ? 0f : 180f;
        characterModel.localEulerAngles = angles;
    }
}
