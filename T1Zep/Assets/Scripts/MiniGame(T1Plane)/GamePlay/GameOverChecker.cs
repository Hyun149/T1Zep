using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverChecker : MonoBehaviour
{
    [SerializeField] private float xLimit = 10f;
    [SerializeField] private float yLimit = -5.7f;

    public bool IsOutOfBounds(Vector2 position)
    {
        return position.x > xLimit || position.y <= yLimit;
    }
}