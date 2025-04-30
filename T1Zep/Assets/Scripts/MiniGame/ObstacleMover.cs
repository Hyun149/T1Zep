using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;

    // Update is called once per frame
    void Update()
    {
        if (!MiniGameManager.IsGameStarted)
        {
            return;
        }

        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (transform.position.x > 10f)
        {
            Destroy(gameObject);
        }
    }
}
