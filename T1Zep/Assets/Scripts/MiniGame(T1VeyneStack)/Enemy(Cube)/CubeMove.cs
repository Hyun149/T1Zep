using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;

    private Vector3 moveDirection;
    private bool isMoving = true;

    public void SetMoveDirection(Vector3 dir)
    {
        moveDirection = dir.normalized;
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
    }

    private void Update()
    {
        if (isMoving)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
    }

    public void SetRandomSpeed()
    {
        moveSpeed = Random.Range(1.5f, 3.5f);
    }
}
