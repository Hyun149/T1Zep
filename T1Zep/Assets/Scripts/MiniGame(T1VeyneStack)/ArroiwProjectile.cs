using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArroiwProjectile : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.x > 20f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("T1Cube"))
        {
            StackScoreManager.Instance.AddScore(1);
            Debug.Log("ИэСп!");

            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
