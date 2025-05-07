using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowProjectile : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("T1Cube"))
        {
            StackScoreManager.Instance.AddScore(1);

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
