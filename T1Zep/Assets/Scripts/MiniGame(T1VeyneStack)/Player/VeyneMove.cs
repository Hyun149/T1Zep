using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VeyneMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;
    private float fixedY;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fixedY = transform.position.y;
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(inputX, 0f, inputZ).normalized;
        Vector3 velocity = direction * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

        Vector3 pos = transform.position;
        pos.y = fixedY;
        transform.position = pos;
    }
}
