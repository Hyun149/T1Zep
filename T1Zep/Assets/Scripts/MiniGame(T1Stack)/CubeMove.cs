using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float maxOffset = 3f;

    private Vector3[] directions = new Vector3[]
    {
        new Vector3(-1f, 0f, 1f).normalized,
        new Vector3(1f, 0f, 1f).normalized
    };

    private int currentDirIndex = 0;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position += directions[currentDirIndex] * moveSpeed * Time.deltaTime;

        float distance = Vector3.Distance(startPosition, transform.position);
        if (distance >= maxOffset)
        {
            startPosition = transform.position;
            currentDirIndex = (currentDirIndex + 1) % directions.Length;
        }
    }
}
