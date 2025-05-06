using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private float lastShootTime = -999f;

    [SerializeField] private ArrowShooter arrowShooter;
    [SerializeField] private float shootCooldown = 0.3f;

    private void Update()
    {      
        if (T1StackGameManager.Instance == null || !T1StackGameManager.Instance.IsGameStarted())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time - lastShootTime < shootCooldown)
            {
                return;
            }

            lastShootTime = Time.time;
            arrowShooter.ShootArrow();
        }
    }
}
