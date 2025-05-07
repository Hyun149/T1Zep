using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VeyneMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private VeyneFacing facingController;

    private Rigidbody rb;
    private float fixedY;
    private Vector3 lastDirection = Vector3.forward;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        fixedY = transform.position.y;
    }

    private void Start()
    {
        if (facingController == null)
        {
            Debug.Log("facingController가 연결되지 않았습니다!");
        }
    }

    private void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(inputX, 0f, inputZ).normalized;

        if (direction != Vector3.zero)
        {
            lastDirection = direction;
            float angle = Mathf.Atan2(lastDirection.z, lastDirection.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, -angle, 0);

            facingController.UpdateFacing(direction);
        }

        Vector3 velocity = direction * moveSpeed;
        rb.velocity = new Vector3(velocity.x, rb.velocity.y, velocity.z);

        Vector3 pos = transform.position;
        pos.y = fixedY;
        transform.position = pos;
    }
}
