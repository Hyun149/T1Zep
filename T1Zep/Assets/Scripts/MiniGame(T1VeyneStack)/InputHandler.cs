using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{

    [SerializeField] private ArrowShooter arrowShooter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            arrowShooter.ShootArrow();
        }
    }
}
